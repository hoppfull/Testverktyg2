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
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace StudentApp
{
    /// <summary>
    /// Interaction logic for TestPage.xaml
    /// </summary>
    public partial class TestPage : Window
    {
        private TestDefinition td;
        private ObservableCollection<Question> testquestions = new ObservableCollection<Question>();
        private TestForm _testForm;
        private StudentAccount _studentAccount;
        private DispatcherTimer _dispatcherTimer;
        private int timer= 0;

        public TestPage(TestForm testform, StudentAccount student)
        {
            InitializeComponent();
            this.DataContext = this;
            using (var db = new Testverktyg.Context.TestverktygContext())
            {
                td = (from d in db.TestDefinitions.Where(x => x.Id == testform.TestDefinitionId).Include(q => q.Questions.Select(a => a.Answers))
                      select d).FirstOrDefault();

            }
            foreach (var item in td.Questions)
            {
                testquestions.Add(item);
            }
            foreach (var question in testquestions)
            {
                if (question.QuestionType == QuestionType.Open)
                {
                    foreach (var answer in question.Answers)
                    {
                        answer.Text = "";
                    }
                }
                else
                {
                    foreach (var answer in question.Answers)
                    {
                        answer.CheckedOrRanked = 0;
                    }
                }
            }
            _testForm = testform;
            _studentAccount = student;

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            _dispatcherTimer = dispatcherTimer;
            _dispatcherTimer.Start();
            _testForm.StartDate = DateTime.Now;
            timer = _testForm.TimeLimit*60;
        }


        public ObservableCollection<Question> TestQuestions
        {
            get { return testquestions; }
            set { testquestions = value; }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var cb = (CheckBox)sender;
            var ctx = (Answer)cb.DataContext;

            if (cb.IsChecked == true)
            {
                ctx.CheckedOrRanked = 1;
            }

            if (cb.IsChecked == false)
            {
                ctx.CheckedOrRanked = 0;
            }
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            var rb = (RadioButton)sender;
            var ctx = (Answer)rb.DataContext;

            if (rb.IsChecked == true)
            {
                ctx.CheckedOrRanked = 1;
            }
            if (rb.IsChecked == false)
            {
                ctx.CheckedOrRanked = 0;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CompleteTest();
        }

        

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan t = TimeSpan.FromSeconds(timer);

            string timetex = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:",
                t.Hours,
                t.Minutes,
                t.Seconds);

            lbTimer.Content = timetex;
            timer--;
            if (timer == 0)
            {
                CompleteTest();
            }
        }

        private void CompleteTest()
        {
            _dispatcherTimer.Stop();
            TestDefinition correctTd = new TestDefinition();
            using (var db = new Testverktyg.Context.TestverktygContext())
            {
                correctTd = db.TestDefinitions.Where(td => td.Id == _testForm.TestDefinitionId).Include(q => q.Questions.Select(a => a.Answers)).FirstOrDefault();
            }
            _testForm.Score = StudentApp.Controllers.StudentController.CalculateScore(TestQuestions, correctTd.Questions);
            _testForm.IsCompleted = true;
            _testForm.FinishedDate = DateTime.Now;
            Repository<TestForm>.Instance.Update(_testForm);

            StudentPage s = new StudentPage(_studentAccount);
            s.Show();
            this.Close();
        }
    }
}


