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
using Testverktyg.Repository;
using System.Data.Entity;

namespace StudentApp
{
    public partial class StudentPage : Window
    {
        public StudentAccount UserAccount { get; }
        public StudentPage(StudentAccount userAccount)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<TestForm> testFormsList = Repository<TestForm>.Instance.GetAll().Where(x => x.StudentAccountId == userAccount.Id && x.IsCompleted == false).ToList();
            List<TestForm> DonetestFormsList = Repository<TestForm>.Instance.GetAll().Where(x => x.StudentAccountId == userAccount.Id && x.IsCompleted == true).ToList();

            UserAccount = userAccount;
            lvw_NotFinsihedTestForms.ItemsSource = testFormsList;
            lvw_FinishedTestForms.ItemsSource = DonetestFormsList;

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Är det säkert att du vill påbörja provet tiden börjar om du trycker JA", "Starta Prvo", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                //Starta provet
                var testForm = new TestForm();
                using (var db = new Testverktyg.Context.TestverktygContext())
                {
                    var selectedTf = (TestForm)lvw_NotFinsihedTestForms.SelectedItem;
                    testForm = db.TestForms.Where(x => x.Id == selectedTf.Id)
                         .Include(a => a.TestDefinition.Questions.Select(b => b.Answers))
                         .FirstOrDefault();
                }
                    TestPage t = new TestPage(testForm, UserAccount);
                t.Show();
                this.Close();
            }
        }
    }
}
