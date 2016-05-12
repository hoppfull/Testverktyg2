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

namespace AdminApp {
    public partial class TeacherPage : Window {
        public TeacherAccount UserAccount { get; }
        public TeacherPage(TeacherAccount userAccount) {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            UserAccount = userAccount;
        }

        #region Teacher settings tools:
        private void tbx_TeacherChangePassword_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void btn_AcceptChangePassword_Click(object sender, RoutedEventArgs e) {

        }

        private void tbx_TeacherChangeEmail_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void btn_AcceptChangeEmail_Click(object sender, RoutedEventArgs e) {

        }
        #endregion
    }
}
