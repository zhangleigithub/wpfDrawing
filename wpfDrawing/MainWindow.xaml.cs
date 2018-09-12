using Summer.WPF.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpfDrawing
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
            {
                CompositeElement e = new CompositeElement();
                e.Location = new Point(i * 100, 200);
                e.Size = new Size(100, 200);
                e.ForeColor = Colors.Transparent;
                e.BackColor = Colors.Transparent;

                e.AddElement(new RoundElement() { Location = new Point(10, 10), Radius = 10, BackColor = Colors.Red, ForeColor = Colors.LightGray });
                e.AddElement(new RoundElement() { Location = new Point(10, 30), Radius = 10, BackColor = Colors.Green, ForeColor = Colors.LightGray });
                e.AddElement(new RoundElement() { Location = new Point(10, 50), Radius = 10, BackColor = Colors.Blue, ForeColor = Colors.LightGray });
                e.AddElement(new LineElement() { BeginPoint = new Point(22, 0), EndPoint = new Point(22, 100), ForeColor = Colors.LightGray });
                e.AddElement(new Summer.WPF.Control.TextElement() { Location = new Point(22, 4), ForeColor = Colors.Black, Text = "通过" });

                cc.AddChildElement(e);
            }

            for (int i = 2; i < 3; i++)
            {
                CompositeElement e = new CompositeElement();
                e.Location = new Point(i * 200, i * 200);
                e.Size = new Size(200, 200);
                e.ForeColor = Colors.LightGray;
                e.BackColor = Colors.White;

                e.AddElement(new LineElement() { BeginPoint = new Point(30, 0), EndPoint = new Point(0, 30), ForeColor = Colors.LightGray });
                e.AddElement(new LineElement() { BeginPoint = new Point(30, 0), EndPoint = new Point(60, 30), ForeColor = Colors.LightGray });
                e.AddElement(new LineElement() { BeginPoint = new Point(0, 30), EndPoint = new Point(60, 30), ForeColor = Colors.LightGray });

                cc.AddChildElement(e);
            }
        }
    }
}
