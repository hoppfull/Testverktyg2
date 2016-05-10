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

        private void btn_ValidateTestDefinition_Click(object sender, RoutedEventArgs e) {

        }

        private void cbx_TimeLimit_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            btn_ValidateTestDefinition.IsEnabled = dpk_FinalDate.SelectedDate != null;
        }

        private void dpk_FinalDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e) {
            btn_ValidateTestDefinition.IsEnabled = cbx_TimeLimit.SelectedIndex != -1 && dpk_FinalDate.SelectedDate != null;
        }
    }
}
