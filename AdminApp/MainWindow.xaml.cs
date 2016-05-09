using System.Windows;
using System.Windows.Controls;
using Testverktyg;
using Testverktyg.Model;
using Testverktyg.Context;
using Testverktyg.Repository;
using AdminApp.Controller;

namespace AdminApp {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            //Console.WriteLine(Controller.Controller.GenerateNewPassword());
            MockData.Reset();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e) {
            tbl_LoginWarning.Visibility = Visibility.Visible;

            switch (ViewController.Login(this, tbx_LoginEmail.Text, tbx_LoginPassword.Text)) {
                case ViewController.LoginResponse.InvalidUser:
                    tbl_LoginWarning.Text = "Ingen sådan användare existerar!";
                    break;
                case ViewController.LoginResponse.InvalidPassword:
                    tbl_LoginWarning.Text = "Felaktigt lösenord!";
                    break;
                case ViewController.LoginResponse.Success:
                    tbl_LoginWarning.Text = "Loggar in...";
                    break;
            }
        }

        private void tbx_LoginField_TextChanged(object sender, TextChangedEventArgs e) {
            tbl_LoginWarning.Visibility = Visibility.Collapsed;
        }
    }
}
