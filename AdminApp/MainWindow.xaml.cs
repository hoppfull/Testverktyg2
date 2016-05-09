using System.Windows;
using Testverktyg;

namespace AdminApp {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            MockData.Reset();

            //TestDefinition test = Testverktyg.Repository.Repository<TestDefinition>.Instance.Get(7);
            //Console.WriteLine(test.Subject);
            //Testverktyg.Repository.Repository<TestDefinition>.Instance.Delete(test);
            //Testverktyg.Repository.Repository<TestDefinition>.Instance.Delete(test);
        }
    }
}
