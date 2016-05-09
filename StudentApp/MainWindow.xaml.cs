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
using System.Windows.Navigation;
using System.Windows.Shapes;
using StudentApp.Controllers;
using Testverktyg;

namespace StudentApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            MockData.Reset();//:>
        }
        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            tbl_LoginWarning.Visibility = Visibility.Visible;

            switch (ViewControllerStudent.Login(this, tbx_LoginEmail.Text, tbx_LoginPassword.Text))
            {
                case ViewControllerStudent.LoginResponse.InvalidUser:
                    tbl_LoginWarning.Text = "Ingen sådan användare existerar!";
                    break;
                case ViewControllerStudent.LoginResponse.InvalidPassword:
                    tbl_LoginWarning.Text = "Felaktigt lösenord!";
                    break;
                case ViewControllerStudent.LoginResponse.Success:
                    tbl_LoginWarning.Text = "Loggar in...";
                    break;
            }
        }

        private void tbx_LoginField_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbl_LoginWarning.Visibility = Visibility.Collapsed;
        }
    }
}

