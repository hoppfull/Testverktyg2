using System;
using System.Windows;

namespace Demo01___WPF_window_spawning {
    public partial class ChildWindow : Window {
        private Window window { get; }
        public ChildWindow(Window w) {
            InitializeComponent();
            window = w;
            window.IsEnabled = false;
        }

        private void win_CloseWindow_Closed(object sender, EventArgs e) {
            window.IsEnabled = true;
        }
    }
}
