using System.Windows;
using Testverktyg;

namespace AdminApp {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            MockData.Reset();
        }
    }
}
