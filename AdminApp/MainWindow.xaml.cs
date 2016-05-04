using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Testverktyg;
using Testverktyg.Model;
using Testverktyg.Context;
using Testverktyg.Repository;

namespace AdminApp {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            Console.WriteLine(Controller.Controller.GenerateNewPassword());
            MockData.Reset();
            //Console.WriteLine(Testverktyg.Controller.Controller.GetTestDefinitionAuthorName(Repository<TestDefinition>.Instance.Get(2)));
            using (var db = new TestverktygContext())
            {
                TeacherAccount t = db.TeacherAccounts.Where(x => x.Id == 1).Include(x => x.TestDefinitions).First();
                Console.WriteLine(t.TestDefinitions.Count);
                //Console.WriteLine(Repository<TeacherAccount>.Instance.GetAll()[0]);
            }
                
        }
    }
}
