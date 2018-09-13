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

            Dictionary<string, IElement> dicElement = new Dictionary<string, IElement>();

            CompositeElement signalMachine = new CompositeElement();
            signalMachine.Location = new Point(0, 0);
            signalMachine.Size = new Size(100, 60);
            signalMachine.ForeColor = Colors.Transparent;
            signalMachine.BackColor = Colors.Transparent;
            signalMachine.AddElement(new RoundElement() { Location = new Point(10, 10), Radius = 10, BackColor = Colors.Red, ForeColor = Colors.LightGray });
            signalMachine.AddElement(new RoundElement() { Location = new Point(10, 30), Radius = 10, BackColor = Colors.Green, ForeColor = Colors.LightGray });
            signalMachine.AddElement(new RoundElement() { Location = new Point(10, 50), Radius = 10, BackColor = Colors.Blue, ForeColor = Colors.LightGray });
            signalMachine.AddElement(new LineElement() { BeginPoint = new Point(22, 0), EndPoint = new Point(22, 100), ForeColor = Colors.LightGray });
            signalMachine.AddElement(new Summer.WPF.Control.TextElement() { Location = new Point(22, 4), ForeColor = Colors.Black, Text = "通过" });

            dicElement["SignalMachine"] = signalMachine;
            string str = Newtonsoft.Json.JsonConvert.SerializeObject(dicElement);
            for (int i = 0; i < 10; i++)
            {
                AbstractElement element = (dicElement["SignalMachine"] as AbstractElement).Clone() as AbstractElement;
                element.Location = new Point(i * 100, 100);

                cc.AddChildElement(element);
            }
        }
    }
}
