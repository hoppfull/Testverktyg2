﻿using System;
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

namespace AdminApp {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            Console.WriteLine(Controller.Controller.GenerateNewPassword());
            MockData.Reset();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        //private void txb_LoginEmail_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    txb_LoginEmail.Foreground = txb_LoginEmail.Text == ""
        //        ? new Brush(Colors.Gray)
        //        : new Brush(Colors.Black);
        //}
    }
}
