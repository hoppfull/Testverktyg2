using System.Windows;
using System.Windows.Controls;

namespace Demo06___WPF_Frame_navigation {
    public enum PageType {
        Red, Green, Blue, NoPage
    }
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            NavigateToPage(PageType.NoPage);
        }

        private void btn_Page_Click(object sender, RoutedEventArgs e) {
            NavigateToPage((PageType)((Button)sender).Tag);
        }

        private void NavigateToPage(PageType tag) {
            frm_RootFrame.Navigate(
                tag == PageType.Red
                    ? new RedPage() as Page :
                tag == PageType.Green
                    ? new GreenPage() as Page :
                tag == PageType.Blue
                    ? new BluePage() as Page :
                    null);
        }
    }
}
