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
using AdminApp.Controllers;

namespace AdminApp {
    public partial class AdminPage : Window {
        public AdminAccount LoggedInAccount { get; }
        public AdminPage(AdminAccount loggedInAccount) {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            LoggedInAccount = loggedInAccount;
        }

        private void btn_EditSubject_Click(object sender, RoutedEventArgs e) {

        }

        private void btn_RemoveSubject_Click(object sender, RoutedEventArgs e) {

        }

        private void btn_AddSubject_Click(object sender, RoutedEventArgs e) {

        }

        private void btn_InspectTestDefinition_Click(object sender, RoutedEventArgs e) {

        }

        private void cbx_SelectUserType_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            UpdateUserListView(GetSelectedUserType());
            skp_EditUser.IsEnabled = false;
        }

        private void lvw_Users_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            skp_EditUser.IsEnabled = true;
        }

        private void btn_AddUser_Click(object sender, RoutedEventArgs e) {
            btn_AddUser.Visibility = Visibility.Collapsed;
            skp_SaveUser.Visibility = Visibility.Visible;
        }

        private void btn_SaveUser_Click(object sender, RoutedEventArgs e) {
            btn_AddUser.Visibility = Visibility.Visible;
            skp_SaveUser.Visibility = Visibility.Collapsed;
            Controller.CreateUser(tbx_AddUserName.Text, tbx_AddUserEmail.Text, GetSelectedUserType());
            UpdateUserListView(GetSelectedUserType());
        }

        private void btn_RemoveUser_Click(object sender, RoutedEventArgs e) {
            if (lvw_Users.SelectedItem != null) {
                ((AbstractUser)lvw_Users.SelectedItem).IsNotRemoved = false;
                if (Controller.DeleteUser(LoggedInAccount, lvw_Users.SelectedItem as AdminAccount)) { }
                else if (Controller.DeleteUser(LoggedInAccount, lvw_Users.SelectedItem as TeacherAccount)) { }
                else if (Controller.DeleteUser(LoggedInAccount, lvw_Users.SelectedItem as StudentAccount)) { }
                UpdateUserListView(GetSelectedUserType());
            }
        }

        private void UpdateUserListView(UserType userType) {
            Func<AbstractUser, bool> f = user => user.IsNotRemoved;
            lvw_Users.ItemsSource =
                userType == UserType.Admin ?
                    Repository<AdminAccount>.Instance.GetAll().Where(f) :
                userType == UserType.Teacher ?
                    Repository<TeacherAccount>.Instance.GetAll().Where(f) :
                userType == UserType.Student ?
                    Repository<StudentAccount>.Instance.GetAll().Where(f) :
                    null;
            skp_EditUser.IsEnabled = false;
        }

        private UserType GetSelectedUserType() {
            return (UserType)((ComboBoxItem)cbx_SelectUserType.SelectedItem).Tag;
        }

        private void btn_ResetUserPassword_Click(object sender, RoutedEventArgs e) {
            if(lvw_Users.SelectedItem != null) {
                Controller.ResetPassword(lvw_Users.SelectedItem as AbstractUser);
                UpdateUserListView(GetSelectedUserType());
            }
        }
    }
}
