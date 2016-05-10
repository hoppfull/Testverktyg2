using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Testverktyg.Model;
using Testverktyg.Controllers;
using Testverktyg.Repository;

namespace AdminApp {
    public partial class InspectTestDefinition : Window {
        private TestDefinition TestDefinition { get; }
        private AdminPage Parent { get; }
        public InspectTestDefinition(AdminPage parent, TestDefinition testDefinition) {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            TestDefinition = testDefinition;
            Parent = parent;
            Parent.IsEnabled = false;
            // TODO: Find better solution:
            parent.Opacity = 0;
        }

        private void btn_ValidateTestDefinition_Click(object sender, RoutedEventArgs e) {
            IList<StudentAccount> students = Repository<StudentAccount>.Instance.GetAll();

            foreach (StudentAccount student in students) {
                Controller.ValidateTestDefinition(TestDefinition,
                    int.Parse((string)((ComboBoxItem)cbx_TimeLimit.SelectedItem).Content),
                    dpk_FinalDate.SelectedDate.Value);
            }

            MessageBox.Show("Provet har godkänts!");
            Close();
        }

        private void cbx_TimeLimit_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            btn_ValidateTestDefinition.IsEnabled = dpk_FinalDate.SelectedDate != null;
        }

        private void dpk_FinalDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e) {
            btn_ValidateTestDefinition.IsEnabled = cbx_TimeLimit.SelectedIndex != -1 && dpk_FinalDate.SelectedDate.HasValue;
        }

        private void win_InspectTestDefinition_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            Parent.IsEnabled = true;
            // TODO: Find better solution:
            Parent.Opacity = 1;
        }
    }
}
