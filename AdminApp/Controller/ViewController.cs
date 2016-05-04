using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdminApp.Controller {
    class ViewController {

        public void Logout(Window window) {
            MainWindow loginscreen = new MainWindow();
            loginscreen.Show();
            window.Close();
        }
    }
}
