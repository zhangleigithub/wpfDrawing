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

namespace wpfSeries
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
                AbstractElement element = ElementFactory.GetInstance()["SignalMachine" + i % 2] as AbstractElement;
                element.Location = new Point(i * 100, 100);

                cc.AddChildElement(element);
            }

            AbstractElement element1 = ElementFactory.GetInstance()["CurveElement1"] as AbstractElement;
            element1.Location = new Point(10, 500);
            cc.AddChildElement(element1);
        }
    }
}
