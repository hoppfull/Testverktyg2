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
            UpdateSubjectListView();
        }

        private void lvw_Subjects_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            skp_EditSubjectTools.IsEnabled = true;
        }

        private void btn_ChangeSubjectName_Click(object sender, RoutedEventArgs e) {
            ToggleChangeSubjectTools(true);
        }

        private void btn_SaveChangeSubjectName_Click(object sender, RoutedEventArgs e) {
            ToggleChangeSubjectTools(false);
        }

        private void btn_AbortChangeSubjectName_Click(object sender, RoutedEventArgs e) {
            ToggleChangeSubjectTools(false);
        }

        private void ToggleChangeSubjectTools(bool enable) {
            btn_ChangeSubjectName.Visibility = enable ? Visibility.Collapsed : Visibility.Visible;
            skp_ChangeSubjectName.Visibility = enable ? Visibility.Visible : Visibility.Collapsed;
        }

        private void btn_RemoveSubject_Click(object sender, RoutedEventArgs e) {

        }

        private void btn_AddSubject_Click(object sender, RoutedEventArgs e) {
            ToggleSaveSubjectTools(true);
        }

        private void btn_SaveSubject_Click(object sender, RoutedEventArgs e) {
            ToggleSaveSubjectTools(false);
        }

        private void btn_AbortSaveSubject_Click(object sender, RoutedEventArgs e) {
            ToggleSaveSubjectTools(false);
        }

        private void ToggleSaveSubjectTools(bool enable) {
            btn_AddSubject.Visibility = enable ? Visibility.Collapsed : Visibility.Visible;
            skp_SaveSubject.Visibility = enable ? Visibility.Visible : Visibility.Collapsed;
        }

        private void UpdateSubjectListView() {
            lvw_Subjects.ItemsSource = Repository<Subject>.Instance.GetAll();
            skp_EditSubjectTools.IsEnabled = false;
        }

        private void btn_InspectTestDefinition_Click(object sender, RoutedEventArgs e) {

        }

        private void cbx_SelectUserType_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            UpdateUserListView(GetSelectedUserType());
            skp_UserTools.Visibility = Visibility.Visible;
        }

        private void lvw_Users_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            skp_EditUser.IsEnabled = true;
        }

        private void btn_AddUser_Click(object sender, RoutedEventArgs e) {
            ToggleSaveUserTools(true);
        }

        private void btn_SaveUser_Click(object sender, RoutedEventArgs e) {
            ToggleSaveUserTools(false);
            Controller.CreateUser(tbx_AddUserName.Text, tbx_AddUserEmail.Text, GetSelectedUserType());
            UpdateUserListView(GetSelectedUserType());
        }

        private void btn_AbortSaveUser_Click(object sender, RoutedEventArgs e) {
            ToggleSaveUserTools(false);
        }

        private void ToggleSaveUserTools(bool enable) {
            btn_AddUser.Visibility = enable ? Visibility.Collapsed : Visibility.Visible;
            skp_SaveUser.Visibility = enable ? Visibility.Visible : Visibility.Collapsed;
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
