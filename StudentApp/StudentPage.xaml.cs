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
using StudentApp.Controllers;

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
                    if (item.FinalDate < DateTime.Now)
                    {
                        Repository<TestForm>.Instance.Delete(item);
                    }
                    else
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
            if (MessageBox.Show("Är det säkert att du vill påbörja provet tiden börjar om du trycker Ja", "Starta Prov", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
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
        private void btn_Logout_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ViewControllerStudent.Logout(this);
        }

        private void tbx_StudentChangePassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            btn_AcceptChangePassword.IsEnabled =
                tbx_StudentChangePassword.Text == tbx_StudentRepeatChangePassword.Text &&
                !string.IsNullOrWhiteSpace(((TextBox)sender).Text);
        }

        private void btn_AcceptChangePassword_Click(object sender, RoutedEventArgs e)
        {
            if (Testverktyg.Controllers.Controller.UpdatePassword(UserAccount, tbx_StudentChangePassword.Text))
            {
                btn_AcceptChangePassword.IsEnabled = false;
                tbx_StudentChangePassword.Text = "";
                tbx_StudentRepeatChangePassword.Text = "";
                MessageBox.Show($"Lösenord ändrat till '{UserAccount.Password}'");
            }
            else
                MessageBox.Show("Kunde inte ändra lösenordet!\nKanske är lösenordet inte giltigt.");

        }

        private void tbx_StudentChangeEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            btn_AcceptChangeEmail.IsEnabled =
                !string.IsNullOrWhiteSpace(tbx_StudentChangeEmail.Text) &&
                tbx_StudentChangeEmail.Text != UserAccount.Email;
        }

        private void btn_AcceptChangeEmail_Click(object sender, RoutedEventArgs e)
        {
            if (Testverktyg.Controllers.Controller.UpdateEmail(UserAccount, tbx_StudentChangeEmail.Text))
            {
                btn_AcceptChangeEmail.IsEnabled = false;
                tbx_StudentChangeEmail.Text = "";
                MessageBox.Show($"Email ändrat till '{UserAccount.Email}'");
            }
            else
                MessageBox.Show("Kunde inte ändra din email!\nKanske är mailen inte giltig.");
        }

    }
}
