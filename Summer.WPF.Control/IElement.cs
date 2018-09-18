using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Summer.WPF.Control
{
    /// <summary>
    /// IElement
    /// </summary>
    public interface IElement : ICloneable
    {
        /// <summary>
        /// OnRender
        /// </summary>
        /// <param name="dc">dc</param>
        void OnRender(DrawingContext dc);
    }
}
