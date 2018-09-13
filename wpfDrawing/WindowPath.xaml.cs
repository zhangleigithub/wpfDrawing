using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace wpfDrawing
{
    /// <summary>
    /// WindowPath.xaml 的交互逻辑
    /// </summary>
    public partial class WindowPath : Window
    {
        public WindowPath()
        {
            InitializeComponent();
        }

        private void OnForePathMouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Point position = e.GetPosition(this.forePath);

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                EllipseGeometry ellipse = new EllipseGeometry();
                ellipse.RadiusX = 10;
                ellipse.RadiusY = 10;
                ellipse.Center = position;
                this.forePath.Data = Geometry.Combine(this.forePath.Data, ellipse, GeometryCombineMode.Exclude, null);
            }
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            this.forePath.Data = Geometry.Combine(this.forePath.Data, this.backPath.Data, GeometryCombineMode.Union, null);
            this.backImage.ImageSource = this.RandomBackImage();
        }

        public ImageSource RandomBackImage()
        {
            string[] str = new string[] { "123", "456", "789" };

            Bitmap image = new Bitmap((int)this.backPath.Width, (int)this.backPath.Height);
            Graphics g = Graphics.FromImage(image);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            Random random = new Random();
            g.FillRectangle(System.Drawing.Brushes.LightGray, new RectangleF(0, 0, image.Width, image.Height));
            g.DrawString(str[random.Next(str.Length - 1)], new Font("Microsoft YaHei", 18, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, new RectangleF(0, 0, image.Width, image.Height), format);
            MemoryStream stream = new MemoryStream();
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            image.Dispose();

            return (ImageSource)(new ImageSourceConverter()).ConvertFrom(stream);
        }
    }
}
