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
using AdminApp.Controller;

namespace AdminApp {
    public enum UserType {
        Admin, Teacher, Student
    }
    public partial class AdminPage : Window {
        public AdminAccount UserAccount { get; }
        public AdminPage(AdminAccount userAccount) {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            UserAccount = userAccount;
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
            switch ((UserType)((ComboBoxItem)cbx_SelectUserType.SelectedItem).Tag) {
                case UserType.Admin:
                    UpdateUserListView<AdminAccount>();
                    break;
                case UserType.Teacher:
                    UpdateUserListView<TeacherAccount>();
                    break;
                case UserType.Student:
                    UpdateUserListView<StudentAccount>();
                    break;
            }
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
        }

        private void btn_RemoveUser_Click(object sender, RoutedEventArgs e) {
            if (lvw_Users.SelectedItem != null) {
                ((AbstractUser)lvw_Users.SelectedItem).IsNotRemoved = false;
                if (UpdateUser(lvw_Users.SelectedItem as AdminAccount)) {
                } else if (UpdateUser(lvw_Users.SelectedItem as TeacherAccount)) {
                } else if (UpdateUser(lvw_Users.SelectedItem as StudentAccount)) {
                }
            }
        }

        private void UpdateUserListView<T>() where T : AbstractUser {
            lvw_Users.ItemsSource = Repository<T>.Instance.GetAll().Where(user => user.IsNotRemoved);
            skp_EditUser.IsEnabled = false;
        }

        private bool UpdateUser<T>(T user) where T : AbstractUser {
            if(user != null) {
                Repository<T>.Instance.Update(user);
                UpdateUserListView<T>();
                return true;
            }
            return false;
        }

        private void btn_ResetUserPassword_Click(object sender, RoutedEventArgs e) {

        }
    }
}
