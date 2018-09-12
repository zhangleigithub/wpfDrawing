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
        #region 字段

        /// <summary>
        /// childrens
        /// </summary>
        private IList<AbstractElement> childrens { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 构造函数
        /// </summary>
        public CompositeElement()
        {
            this.childrens = new List<AbstractElement>();
        }

        /// <summary>
        /// AddElement
        /// </summary>
        /// <param name="element">element</param>
        public void AddElement(AbstractElement element)
        {
            element.Parent = this;
            this.childrens.Add(element);
        }

        /// <summary>
        /// OnRender
        /// </summary>
        /// <param name="dc">dc</param>
        public override void OnRender(DrawingContext dc)
        {
            dc.DrawRectangle(this.GetBrush(this.BackColor), this.GetPen(this.ForeColor), this.Bounds);

            foreach (var item in this.childrens)
            {
                item.OnRender(dc);
            }
        }

        #endregion
    }
}
