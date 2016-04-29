using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo02___Nested_datatemplates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Customer> customers = new List<Customer>
            {
                new Customer { Name="Andreas", Age=12,
                Products=new List<Product> { new Product { ItemName="Pineapple", Price=20 },
                                             new Product { ItemName="Orange", Price=10 } } },
                new Customer { Name="Björn", Age=114,
                Products=new List<Product> { new Product { ItemName="Banana", Price=30 },
                                             new Product { ItemName="Pear", Price=40 } } }

            };
            lv_Cust.ItemsSource = customers;
        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Product> Products { get; set; }
    }

    public class Product
    {
        public string ItemName { get; set; }
        public int Price { get; set; }
    }
}
