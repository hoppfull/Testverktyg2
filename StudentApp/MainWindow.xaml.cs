﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using StudentApp.Controllers;

namespace StudentApp {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            //Testverktyg.MockData.Reset();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void btn_Login_Click(object sender, RoutedEventArgs e) {
            tbl_LoginWarning.Visibility = Visibility.Visible;

            switch (ViewControllerStudent.Login(this, tbx_LoginEmail.Text.ToLower(), tbx_LoginPassword.Password)) {
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

        private void tbx_LoginField_TextChanged(object sender, TextChangedEventArgs e) {
            tbl_LoginWarning.Visibility = Visibility.Collapsed;
        }

        private void tbx_LoginPassword_PasswordChanged(object sender, RoutedEventArgs e) {
            tbl_LoginWarning.Visibility = Visibility.Collapsed;
        }
    }

    public class RowNumberConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            CollectionViewSource collectionViewSource = parameter as CollectionViewSource;

            int counter = 1;
            foreach (object item in collectionViewSource.View) {
                if (item == value) {
                    return counter.ToString();
                }
                counter++;
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
