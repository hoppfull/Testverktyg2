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
    public partial class AdminPage : Window {
        public AdminAccount UserAccount { get; }
        public AdminPage(AdminAccount userAccount) {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            UserAccount = userAccount;
        }

        private void btn_EditSubject_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_RemoveSubject_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_AddSubject_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_InspectTestDefinition_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
