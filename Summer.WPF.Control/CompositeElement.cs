using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Summer.WPF.Control
{
    /// <summary>
    /// CompositeElement
    /// </summary>
    public class CompositeElement : AbstractElement, IElement
    {
        #region 属性

        /// <summary>
        /// Childrens
        /// </summary>
        public IList<AbstractElement> Children { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 构造函数
        /// </summary>
        public CompositeElement()
        {
            this.Children = new List<AbstractElement>();
        }

        /// <summary>
        /// AddElement
        /// </summary>
        /// <param name="element">element</param>
        public void AddElement(AbstractElement element)
        {
            this.Children.Add(element);
        }

        /// <summary>
        /// OnRender
        /// </summary>
        /// <param name="dc">dc</param>
        public override void OnRender(DrawingContext dc)
        {
            dc.DrawRectangle(this.GetBrush(this.BackColor), this.GetPen(this.ForeColor), this.Bounds);

            foreach (var item in this.Children)
            {
                item.Parent = this;
                item.OnRender(dc);
            }
        }

        /// <summary>
        /// Clone
        /// </summary>
        /// <returns>object</returns>
        public override object Clone()
        {
            CompositeElement clone = new CompositeElement();
            clone.Location = this.Location;
            clone.Size = this.Size;
            clone.ForeColor = this.ForeColor;
            clone.BackColor = this.BackColor;

            foreach (var item in this.Children)
            {
                clone.AddElement(item.Clone() as AbstractElement);
            }

            return clone;
        }

        #endregion
    }
}
