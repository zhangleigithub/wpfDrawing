using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Xml.Linq;

namespace Summer.WPF.Control
{
    /// <summary>
    /// ElementFactory
    /// </summary>
    public class ElementFactory
    {
        #region 字段

        /// <summary>
        /// instance
        /// </summary>
        private static ElementFactory instance = new ElementFactory();

        /// <summary>
        /// elements
        /// </summary>
        private IDictionary<string, IElement> elements = new Dictionary<string, IElement>();

        #endregion

        #region 属性

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IElement this[string key]
        {
            get
            {
                return elements[key].Clone() as IElement;
            }
        }

        #endregion

        #region 外部方法

        /// <summary>
        /// GetInstance
        /// </summary>
        /// <returns>instance</returns>
        public static ElementFactory GetInstance()
        {
            return instance;
        }

        #endregion

        #region 内部方法

        /// <summary>
        /// 构造函数
        /// </summary>
        private ElementFactory()
        {
            XDocument doc = XDocument.Load("AppData\\Elements.xml");

            foreach (var item in doc.Root.Elements())
            {
                string name = item.Attribute("name").Value;
                this.elements[name] = this.Parase(item) as IElement;
            }
        }

        /// <summary>
        /// Parase
        /// </summary>
        /// <param name="xe">xe</param>
        /// <returns>object</returns>
        private object Parase(XElement xe)
        {
            string name = xe.Attribute("name").Value;
            string[] types = xe.Attribute("type").Value.Split(',');

            object obj = Activator.CreateInstance(types[1], types[0]).Unwrap();

            //name
            PropertyInfo propertyInfo = obj.GetType().GetProperty("Name");
            propertyInfo.SetValue(obj, name, null);

            foreach (var item in xe.Elements())
            {
                string propertyName = item.Attribute("name").Value;
                string propertyValue = string.Empty;

                if (item.Attribute("value") != null)
                {
                    propertyValue = item.Attribute("value").Value;
                }

                propertyInfo = obj.GetType().GetProperty(propertyName);

                if (propertyInfo.PropertyType == typeof(System.Windows.Point))
                {
                    string[] strPoint = propertyValue.Split(',');
                    propertyInfo.SetValue(obj, new Point(double.Parse(strPoint[0]), double.Parse(strPoint[1])), null);
                }
                else if (propertyInfo.PropertyType == typeof(IList<System.Windows.Point>))
                {
                    IList<System.Windows.Point> points = new List<System.Windows.Point>();
                    string[] strPoint = propertyValue.Split(',');

                    for (int i = 0; i < strPoint.Length; i++)
                    {
                        points.Add(new Point(double.Parse(strPoint[i]), double.Parse(strPoint[i + 1])));
                        i++;
                    }

                    propertyInfo.SetValue(obj, points, null);
                }
                else if (propertyInfo.PropertyType == typeof(Size))
                {
                    string[] strPoint = propertyValue.Split(',');
                    propertyInfo.SetValue(obj, new Size(double.Parse(strPoint[0]), double.Parse(strPoint[1])), null);
                }
                else if (propertyInfo.PropertyType == typeof(int))
                {
                    propertyInfo.SetValue(obj, int.Parse(propertyValue), null);
                }
                else if (propertyInfo.PropertyType == typeof(string))
                {
                    propertyInfo.SetValue(obj, propertyValue, null);
                }
                else if (propertyInfo.PropertyType == typeof(Color))
                {
                    System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml(propertyValue);
                    propertyInfo.SetValue(obj, Color.FromArgb(color.A, color.R, color.G, color.B), null);
                }
                else if (propertyInfo.PropertyType == typeof(IList<AbstractElement>))
                {
                    IList<AbstractElement> lst = new List<AbstractElement>();

                    foreach (var itemC in item.Elements())
                    {
                        lst.Add(this.Parase(itemC) as AbstractElement);
                    }

                    propertyInfo.SetValue(obj, lst, null);
                }
            }

            return obj;
        }

        #endregion
    }
}
