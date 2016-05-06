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
using System.Windows.Shapes;
using Testverktyg.Model;

namespace AdminApp {
    public partial class InspectTestDefinition : Window {
        public InspectTestDefinition(TestDefinition testDefinition) {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    }
}
