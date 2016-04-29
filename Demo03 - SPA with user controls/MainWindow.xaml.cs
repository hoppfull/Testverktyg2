using System.Windows;

namespace Demo03___SPA_with_user_controls {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void btn_Page1_Click(object sender, RoutedEventArgs e) {
            pg_PageOne.Visibility = Visibility.Visible;
            pg_PageTwo.Visibility = Visibility.Collapsed;
        }

        private void btn_Page2_Click(object sender, RoutedEventArgs e) {
            pg_PageTwo.Visibility = Visibility.Visible;
            pg_PageOne.Visibility = Visibility.Collapsed;
        }
    }
}
