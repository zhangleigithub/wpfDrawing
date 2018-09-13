using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Summer.WPF.Control
{
    /// <summary>
    /// AbstractElement
    /// </summary>
    public abstract class AbstractElement : IElement, ICloneable
    {
        #region 字段

        /// <summary>
        /// dicPen
        /// </summary>
        private static IDictionary<Color, Pen> dicPen = new Dictionary<Color, Pen>();

        /// <summary>
        /// dicBrush
        /// </summary>
        private static IDictionary<Color, Brush> dicBrush = new Dictionary<Color, Brush>();

        #endregion

        #region 属性

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Location
        /// </summary>
        public Point Location { get; set; }

        /// <summary>
        /// Size
        /// </summary>
        public virtual Size Size { get; set; }

        /// <summary>
        /// RectBounds
        /// </summary>
        public Rect Bounds
        {
            get
            {
                return new Rect(this.Location, this.Size);
            }
        }

        /// <summary>
        /// ForeColor
        /// </summary>
        public Color ForeColor { get; set; }

        /// <summary>
        /// BackColor
        /// </summary>
        public Color BackColor { get; set; }

        /// <summary>
        /// Parent
        /// </summary>
        public AbstractElement Parent { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// GetPen
        /// </summary>
        /// <param name="color">color</param>
        /// <returns>Pen</returns>
        public Pen GetPen(Color color)
        {
            if (!dicPen.ContainsKey(color))
            {
                dicPen.Add(color, new Pen(new SolidColorBrush(color), 1));
            }

            return dicPen[color];
        }

        /// <summary>
        /// GetBrush
        /// </summary>
        /// <param name="color">color</param>
        /// <returns>Brush</returns>
        public Brush GetBrush(Color color)
        {
            if (!dicBrush.ContainsKey(color))
            {
                dicBrush.Add(color, new SolidColorBrush(color));
            }

            return dicBrush[color];
        }

        /// <summary>
        /// OnRender
        /// </summary>
        /// <param name="dc">dc</param>
        public abstract void OnRender(DrawingContext dc);

        /// <summary>
        /// Clone
        /// </summary>
        /// <returns>object</returns>
        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }

}
