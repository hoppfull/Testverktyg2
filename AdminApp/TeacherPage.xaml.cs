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
    public partial class TeacherPage : Window {
        public TeacherAccount LoggedInAccount { get; }
        public TeacherPage(TeacherAccount loginAccount) {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            LoggedInAccount = loginAccount;
            lvw_CreatedTestDefinitions.ItemsSource = new List<Tuple<string, string, string, string, bool>> {
                Tuple.Create("Naturprov", "Naturvetenskap", "5", "23", false),
                Tuple.Create("Samhällsprov", "Samhällsvetenskap", "7", "75", false),
                Tuple.Create("Dataprov", "Datavetenskap", "11", "101", false),
                Tuple.Create("Springprov", "Gymnastik", "9", "66", true),
                Tuple.Create("Kemiprov", "Kemi", "2", "25", true)
            };

            lvw_SentTestDefinitions.ItemsSource = new List<Tuple<string, string, string, string>> {
                Tuple.Create("Naturprov", "Naturvetenskap", "5", "23"),
                Tuple.Create("Samhällsprov", "Samhällsvetenskap", "7", "75"),
                Tuple.Create("Dataprov", "Datavetenskap", "11", "101"),
                Tuple.Create("Springprov", "Gymnastik", "9", "66"),
                Tuple.Create("Kemiprov", "Kemi", "2", "25")
            };
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
        private void lvw_CreatedTestDefinitions_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void lvw_SentTestDefinitions_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void btn_NewTestDefinition_Click(object sender, RoutedEventArgs e) {

        }

        private void btn_SaveNewTestDefinition_Click(object sender, RoutedEventArgs e) {

        }

        private void btn_AbortNewTestDefinition_Click(object sender, RoutedEventArgs e) {

        }

        private void cbx_NewTestDefinitionSubject_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void btn_EditTestDefinition_Click(object sender, RoutedEventArgs e) {

        }

        private void btn_SendTestDefinition_Click(object sender, RoutedEventArgs e) {

        }

        private void btn_DeleteTestDefinition_Click(object sender, RoutedEventArgs e) {

        }
        #endregion
    }
}
