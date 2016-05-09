using System.Windows;
using Testverktyg;

namespace AdminApp {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            MockData.Reset();

            Console.WriteLine(Testverktyg.Controller.Controller.CreateTest("hej", Testverktyg.Repository.Repository<Subject>.Instance.Get(1)));
            //TestDefinition test = Testverktyg.Repository.Repository<TestDefinition>.Instance.Get(7);
            //Console.WriteLine(test.Subject);
            //Testverktyg.Repository.Repository<TestDefinition>.Instance.Delete(test);
            //Testverktyg.Repository.Repository<TestDefinition>.Instance.Delete(test);
        }
    }
}
