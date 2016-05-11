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
        public List<DisplayedTest> DisplayedTests
        { get { return displayedtests; } set { displayedtests = value; } }
        private List<DisplayedTest> displayedtests = new List<DisplayedTest>();
        public StudentAccount UserAccount { get; }
        private List<object> _doneTest = new List<object>();
        
        public StudentPage(StudentAccount userAccount)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            List<TestForm> testFormsList = new List<TestForm>();
            List<TestForm> DonetestFormsList = new List<TestForm>();
            List<TestForm> NotDonetestFormsList = new List<TestForm>();

            
            using (var db = new Testverktyg.Context.TestverktygContext())
            {
                testFormsList = db.TestForms.Where(x => x.StudentAccountId == userAccount.Id).Include(q => q.TestDefinition.Questions).ToList();

                foreach (var item in testFormsList)
                {
                    
                    if (item.IsCompleted == true)
                    {
                        DonetestFormsList.Add(item);
                    }
                    else
                    {
                        NotDonetestFormsList.Add(item);
                    }
                }

            }

            UserAccount = userAccount;
            lvw_NotFinsihedTestForms.ItemsSource = NotDonetestFormsList;
            foreach (var item in DonetestFormsList)
            {
                DisplayedTests.Add(new DisplayedTest(item));
            }
            lvw_FinishedTestForms.ItemsSource = DisplayedTests;
            

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Är det säkert att du vill påbörja provet tiden börjar om du trycker JA", "Starta Prvo", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                //Starta provet
                var testForm = new TestForm();
                using (var db = new Testverktyg.Context.TestverktygContext())
                {
                    if (lvw_NotFinsihedTestForms.SelectedItem != null)
                    {
                        var selectedTf = (TestForm)lvw_NotFinsihedTestForms.SelectedItem;
                        testForm = db.TestForms.Where(x => x.Id == selectedTf.Id)
                             .Include(a => a.TestDefinition.Questions.Select(b => b.Answers))
                             .FirstOrDefault();
                    }
                    
                }
                    TestPage t = new TestPage(testForm, UserAccount);
                t.Show();
                this.Close();
            }
        }
    }
}
