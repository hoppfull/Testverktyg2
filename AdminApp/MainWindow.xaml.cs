using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using Testverktyg;
using Testverktyg.Model;
using Testverktyg.Context;
using Testverktyg.Repository;
using Testverktyg.Controllers;

namespace AdminApp {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            MockData.Reset();
            Console.WriteLine(Controller.GetTestDefinitionAuthorName(Repository<TestDefinition>.Instance.Get(1)));
            Console.WriteLine(Controller.GetTestDefinitionAuthorName(Repository<TestDefinition>.Instance.Get(3)));

        }
    }
}
