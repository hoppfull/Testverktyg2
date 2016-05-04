using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            //MockData.Reset();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e) {
            tbl_LoginWarning.Visibility = Visibility.Visible;

            switch (ViewController.Login(this, tbx_LoginEmail.Text, tbx_LoginPassword.Text)) {
                case ViewController.LoginResponse.InvalidUser:
                    tbl_LoginWarning.Text = "No such user exists!";
                    break;
                case ViewController.LoginResponse.InvalidPassword:
                    tbl_LoginWarning.Text = "Invalid password!";
                    break;
                case ViewController.LoginResponse.Success:
                    tbl_LoginWarning.Text = "Logging in...";
                    break;
            }
        }

        private void tbx_LoginField_TextChanged(object sender, TextChangedEventArgs e) {
            tbl_LoginWarning.Visibility = Visibility.Collapsed;
        }
    }
}
