using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Summer.WPF.Control
{
    /// <summary>
    /// TextElement
    /// </summary>
    public class TextElement : AbstractElement
    {
        #region 字段

        /// <summary>
        /// Text
        /// </summary>
        public string Text { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// OnRender
        /// </summary>
        /// <param name="dc">dc</param>
        public override void OnRender(DrawingContext dc)
        {
            dc.DrawText(new FormattedText(this.Text, System.Globalization.CultureInfo.CurrentCulture, System.Windows.FlowDirection.LeftToRight, new Typeface("宋体"), 18, this.GetBrush(this.ForeColor)), Point.Add(this.Location, new Vector() { X = this.Parent.Location.X, Y = this.Parent.Location.Y }));
        }

        #endregion
    }
}
