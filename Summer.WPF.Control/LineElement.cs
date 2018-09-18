using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Summer.WPF.Control
{
    /// <summary>
    /// LineElement
    /// </summary>
    public class LineElement : AbstractElement
    {
        #region 字段

        /// <summary>
        /// endPoint
        /// </summary>
        private Point endPoint;

        #endregion

        #region 属性

        /// <summary>
        /// BeginPoint
        /// </summary>
        public Point BeginPoint
        {
            private get
            {
                return Point.Add(this.Parent.Location, new Vector(this.Location.X, this.Location.Y));
            }
            set
            {
                this.Location = value;
            }
        }

        /// <summary>
        /// EndPoint
        /// </summary>
        public Point EndPoint
        {
            private get
            {
                return Point.Add(this.Parent.Location, new Vector(this.endPoint.X, this.endPoint.Y));
            }
            set
            {
                this.endPoint = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// OnRender
        /// </summary>
        /// <param name="dc">dc</param>
        public override void OnRender(DrawingContext dc)
        {
            dc.DrawLine(this.GetPen(this.ForeColor), this.BeginPoint, this.EndPoint);
        }

        #endregion
    }
}
