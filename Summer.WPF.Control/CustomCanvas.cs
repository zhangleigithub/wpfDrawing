using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Summer.WPF.Control
{
    /// <summary>
    /// CustomCanvas
    /// </summary>
    public class CustomCanvas : Canvas
    {
        #region 字段

        /// <summary>
        /// elements
        /// </summary>
        private IList<IElement> elements = new List<IElement>();

        #endregion

        #region 方法

        /// <summary>
        /// 构造函数
        /// </summary>
        public CustomCanvas()
        {
            this.CacheMode = new BitmapCache();
        }

        /// <summary>
        /// AddChildElement
        /// </summary>
        /// <param name="element">element</param>
        public void AddChildElement(IElement element)
        {
            this.elements.Add(element);
        }

        /// <summary>
        /// OnRender
        /// </summary>
        /// <param name="dc">dc</param>
        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);
            
            foreach (var item in this.elements)
            {
                item.OnRender(dc);
            }
        }

        #endregion
    }
}
