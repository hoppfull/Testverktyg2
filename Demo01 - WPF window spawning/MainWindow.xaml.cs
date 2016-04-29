using System.Windows;

namespace Demo01___WPF_window_spawning {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void btn_SpawnWindow_Click(object sender, RoutedEventArgs e) {
            ChildWindow window = new ChildWindow(this);
            window.Show();
        }
    }
}
