using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace wpfSeries
{
    public class DependencyObjectTest : System.Windows.DependencyObject
    {
        public dynamic Dy { get; set; }

        public int Age
        {
            get { return (int)GetValue(AgeProperty); }
            set { SetValue(AgeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Age.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AgeProperty =
            DependencyProperty.Register("Age", typeof(int), typeof(DependencyObjectTest), new PropertyMetadata(0));



        public IEnumerable Address
        {
            get { return (ObservableCollection<int>)GetValue(AddressProperty); }
            set { SetValue(AddressProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddressProperty =
            DependencyProperty.Register("Address", typeof(IEnumerable), typeof(DependencyObjectTest), new PropertyMetadata(default(IEnumerable),
                delegate (DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                BindingExpressionBase beb = BindingOperations.GetBindingExpressionBase(d, AddressProperty);

                INotifyCollectionChanged obj = (INotifyCollectionChanged)(((DependencyObjectTest)d).Address);
                obj.CollectionChanged += delegate (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs ee)
                {
                    if (ee.NewItems != null)
                    {
                        Console.WriteLine("New:" + ee.NewItems.Count);
                    }
                    else
                    {
                        Console.WriteLine("New: null");
                    }

                    if (ee.OldItems != null)
                    {
                        Console.WriteLine("Old:" + ee.OldItems.Count);
                    }
                    else
                    {
                        Console.WriteLine("Old: null");
                    }
                };
            }));

        public DependencyObjectTest()
        {
            Dy = new Dy();
            Dy.Age = 10;
            Dy.Address = new ObservableCollection<int>();
            Binding bindAge = new Binding("Age") { Source = Dy };
            Binding bindAddress = new Binding("Address") { Source = Dy };

            BindingOperations.SetBinding(this, DependencyObjectTest.AgeProperty, bindAge);
            BindingOperations.SetBinding(this, DependencyObjectTest.AddressProperty, bindAddress);
        }
    }

    public class Dy : System.Dynamic.DynamicObject, INotifyPropertyChanged
    {
        private Dictionary<string, object> dic = new Dictionary<string, object>();

        public event PropertyChangedEventHandler PropertyChanged;

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return dic.TryGetValue(binder.Name, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            dic[binder.Name] = value;

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(binder.Name));
            }

            return true;
        }
    }
}
