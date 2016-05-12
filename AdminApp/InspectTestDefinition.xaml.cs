using System.Windows;
using System.Windows.Controls;
using Testverktyg.Model;
using Testverktyg.Controllers;
using Testverktyg.Repository;

namespace AdminApp {
    public partial class InspectTestDefinition : Window {
        private TestDefinition TestDefinition { get; }
        private AdminPage AdminPage { get; }
        public InspectTestDefinition(AdminPage adminPage, TestDefinition testDefinition) {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            TestDefinition = testDefinition;
            AdminPage = adminPage;
            AdminPage.IsEnabled = false;
        }

        private void btn_ValidateTestDefinition_Click(object sender, RoutedEventArgs e) {
            foreach (StudentAccount student in Repository<StudentAccount>.Instance.GetAll())
                Controller.ValidateTestDefinition(TestDefinition, student,
                    int.Parse((string)((ComboBoxItem)cbx_TimeLimit.SelectedItem).Content),
                    dpk_FinalDate.SelectedDate.Value);
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
            AdminPage.IsEnabled = true;
        }

        private void btn_ReturnTestDefinition_Click(object sender, RoutedEventArgs e) {
            Controller.ReturnTestDefinition(TestDefinition);
            AdminPage.UpdateTestDefinitionListView();
            Close();
        }
    }
}
