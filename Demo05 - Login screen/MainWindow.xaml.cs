using System.Windows;

namespace Demo05___Login_screen {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e) {
            LoggedInWindow w = new LoggedInWindow();
            w.Show();
            Close();
        }
    }
}
