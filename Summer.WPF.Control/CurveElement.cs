using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Summer.WPF.Control
{
    /// <summary>
    /// CurveElement
    /// </summary>
    public class CurveElement : AbstractElement
    {
        #region 属性

        /// <summary>
        /// Points
        /// </summary>
        public IList<Point> Points { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// OnRender
        /// </summary>
        /// <param name="dc">dc</param>
        public override void OnRender(DrawingContext dc)
        {
            StreamGeometry sg = new StreamGeometry();

            using (StreamGeometryContext sgc = sg.Open())
            {
                sgc.BeginFigure(new Point(this.Parent.Location.X + this.Location.X, this.Parent.Location.Y + this.Location.Y), false, false);

                IList<Point> temp = new List<Point>();

                foreach (var item in this.Points)
                {
                    temp.Add(Point.Add(this.Parent.Location, new Vector(item.X, item.Y)));
                }

                sgc.PolyLineTo(temp, true, true);

                sgc.Close();
            }

            dc.DrawGeometry(this.GetBrush(this.BackColor), this.GetPen(this.ForeColor), sg);
        }

        #endregion
    }
}
