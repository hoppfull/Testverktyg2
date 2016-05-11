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
using Testverktyg.Repository;
using Testverktyg.Controllers;

namespace AdminApp {
    public partial class TeacherPage : Window {
        public TeacherAccount LoggedInAccount { get; }
        public TeacherPage(TeacherAccount loginAccount) {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            LoggedInAccount = loginAccount;
            cbx_NewTestDefinitionSubject.ItemsSource = Repository<Subject>.Instance.GetAll();
            UpdateCreatedTestDefinitionsListView();
            UpdateSentTestDefinitionListView();
        }

        #region Teacher settings tools:
        private void tbx_ChangePassword_TextChanged(object sender, TextChangedEventArgs e) {
            btn_AcceptChangePassword.IsEnabled =
                tbx_ChangePassword.Text == tbx_RepeatChangePassword.Text &&
                !string.IsNullOrWhiteSpace(((TextBox)sender).Text);
        }

        private void btn_AcceptChangePassword_Click(object sender, RoutedEventArgs e) {
            if (Testverktyg.Controllers.Controller.UpdatePassword(LoggedInAccount, tbx_ChangePassword.Text)) {
                btn_AcceptChangePassword.IsEnabled = false;
                tbx_ChangePassword.Text = "";
                tbx_RepeatChangePassword.Text = "";
                MessageBox.Show($"Lösenord ändrat till '{LoggedInAccount.Password}'");
            } else
                MessageBox.Show("Kunde inte ändra lösenordet!\nKanske är lösenordet inte giltigt.");
        }

        private void tbx_ChangeEmail_TextChanged(object sender, TextChangedEventArgs e) {
            btn_AcceptChangeEmail.IsEnabled =
                !string.IsNullOrWhiteSpace(tbx_ChangeEmail.Text) &&
                tbx_ChangeEmail.Text != LoggedInAccount.Email;
        }

        private void btn_AcceptChangeEmail_Click(object sender, RoutedEventArgs e) {
            if (Testverktyg.Controllers.Controller.UpdateEmail(LoggedInAccount, tbx_ChangeEmail.Text)) {
                btn_AcceptChangeEmail.IsEnabled = false;
                tbx_ChangeEmail.Text = "";
            } else
                MessageBox.Show("Kunde inte ändra din email!\nKanske är mailen inte giltig.");
        }
        #endregion

        #region Test management tools:
        private void UpdateCreatedTestDefinitionsListView() {
            lvw_CreatedTestDefinitions.ItemsSource = Repository<TestDefinition>.Instance.GetAll()
                .Where(td => td.IsNotRemoved && td.TeacherAccountId == LoggedInAccount.Id &&
                    (td.TestDefinitionState == TestDefinitionState.Created || td.TestDefinitionState == TestDefinitionState.Returned))
                .Select(td => Tuple.Create(td,
                    Repository<Subject>.Instance.Get(td.SubjectId).Name,
                    Repository<Question>.Instance.GetAll().Where(q => q.TestDefinitionId == td.Id).Count(),
                    td.TestDefinitionState == TestDefinitionState.Created));
            skp_EditTestDefinitionTools.IsEnabled = false;
        }

        private void UpdateSentTestDefinitionListView() {
            lvw_SentTestDefinitions.ItemsSource = Repository<TestDefinition>.Instance.GetAll()
                .Where(td => td.IsNotRemoved && td.TeacherAccountId == LoggedInAccount.Id && td.TestDefinitionState == TestDefinitionState.Sent)
                .Select(td => Tuple.Create(td.Title, Repository<Subject>.Instance.Get(td.SubjectId).Name));
        }

        private void lvw_CreatedTestDefinitions_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            skp_EditTestDefinitionTools.IsEnabled = true;
        }

        private void btn_NewTestDefinition_Click(object sender, RoutedEventArgs e) {
            ToggleTestDefinitionTools(true);
        }

        private void btn_SaveNewTestDefinition_Click(object sender, RoutedEventArgs e) {
            if (Controller.CreateTestDefinition(tbx_NewTestDefinitionName.Text, (Subject)cbx_NewTestDefinitionSubject.SelectedItem, LoggedInAccount)) {
                ToggleTestDefinitionTools(false);
                UpdateCreatedTestDefinitionsListView();
            } else
                MessageBox.Show("Kunde inte skapa nytt prov!\nKanske är namnet ogiltigt eller redan taget.");
        }

        private void btn_AbortNewTestDefinition_Click(object sender, RoutedEventArgs e) {
            ToggleTestDefinitionTools(false);
        }

        private void ToggleTestDefinitionTools(bool enable) {
            btn_NewTestDefintion.Visibility = enable
                ? Visibility.Collapsed : Visibility.Visible;
            skp_AddTestDefinitionTools.Visibility = enable
                ? Visibility.Visible : Visibility.Collapsed;
            tbx_NewTestDefinitionName.Text = "";
            cbx_NewTestDefinitionSubject.SelectedIndex = -1;
        }

        private void cbx_NewTestDefinitionSubject_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            btn_SaveNewTestDefinition.IsEnabled = cbx_NewTestDefinitionSubject.SelectedIndex != -1;
        }

        private void btn_EditTestDefinition_Click(object sender, RoutedEventArgs e) {
            DefineTestDefinition w = new DefineTestDefinition(this, GetSelectedTestDefinition());
            w.Show();
        }

        private void btn_SendTestDefinition_Click(object sender, RoutedEventArgs e) {
            if (Controller.SendTestDefinitionForValidation(GetSelectedTestDefinition())) {
                UpdateCreatedTestDefinitionsListView();
                UpdateSentTestDefinitionListView();
            } else
                MessageBox.Show("Kunde inte skicka prov för validering!\nNågot gick fel.");
        }

        private void btn_DeleteTestDefinition_Click(object sender, RoutedEventArgs e) {
            if (Controller.DeleteTestDefinition(GetSelectedTestDefinition())) {
                UpdateCreatedTestDefinitionsListView();
            } else
                MessageBox.Show("Kunde inte ta bort prov!\nNågot gick fel.");
        }

        private TestDefinition GetSelectedTestDefinition() {
            return ((Tuple<TestDefinition, string, int, bool>)lvw_CreatedTestDefinitions.SelectedItem).Item1;
        }
        #endregion
    }
}
