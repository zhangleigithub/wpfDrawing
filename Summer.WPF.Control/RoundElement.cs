using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Summer.WPF.Control
{
    /// <summary>
    /// RoundElement
    /// </summary>
    public class RoundElement : AbstractElement
    {
        #region 属性

        /// <summary>
        /// Radius
        /// </summary>
        public int Radius { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// OnRender
        /// </summary>
        /// <param name="dc">dc</param>
        public override void OnRender(DrawingContext dc)
        {
            dc.DrawEllipse(this.GetBrush(this.BackColor), this.GetPen(this.ForeColor), Point.Add(this.Location, new Vector() { X = this.Parent.Location.X, Y = this.Parent.Location.Y }), this.Radius, this.Radius);
        }

        #endregion
    }
}
