using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Testverktyg.Model;
using Testverktyg.Controllers;
using Testverktyg.Repository;

namespace AdminApp {
    public partial class InspectTestDefinition : Window {
        private TestDefinition TestDefinition { get; }
        public InspectTestDefinition(TestDefinition testDefinition) {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            TestDefinition = testDefinition;
        }

        private void btn_ValidateTestDefinition_Click(object sender, RoutedEventArgs e) {
            IList<StudentAccount> students = Repository<StudentAccount>.Instance.GetAll();

            foreach (StudentAccount student in students) {
                Controller.ValidateTestDefinition(TestDefinition,
                    int.Parse((string)((ComboBoxItem)cbx_TimeLimit.SelectedItem).Content),
                    dpk_FinalDate.SelectedDate.Value);
            }
        }

        private void cbx_TimeLimit_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            btn_ValidateTestDefinition.IsEnabled = dpk_FinalDate.SelectedDate != null;
        }

        private void dpk_FinalDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e) {
            btn_ValidateTestDefinition.IsEnabled = cbx_TimeLimit.SelectedIndex != -1 && dpk_FinalDate.SelectedDate.HasValue;
        }
    }
}
