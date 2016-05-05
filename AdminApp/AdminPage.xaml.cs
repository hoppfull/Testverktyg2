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
                    lvw_Users.ItemsSource = Repository<AdminAccount>.Instance.GetAll();
                    break;
                case UserType.Teacher:
                    lvw_Users.ItemsSource = Repository<TeacherAccount>.Instance.GetAll();
                    break;
                case UserType.Student:
                    lvw_Users.ItemsSource = Repository<StudentAccount>.Instance.GetAll();
                    break;
            }
        }

        private void lvw_Users_SelectionChanged(object sender, SelectionChangedEventArgs e) {

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
            
        }

        private void btn_ResetUserPassword_Click(object sender, RoutedEventArgs e) {

        }
    }
}
