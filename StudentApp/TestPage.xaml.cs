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
            //reset CheckedOrRanked to zero
            foreach (var question in testquestions)
            {
                foreach (var answer in question.Answers)
                {
                    answer.CheckedOrRanked = 0;
                }
            }



            _testForm = testform;
            Console.WriteLine();
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
            //_testForm.AnsweredQuestions.
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
            foreach (var item in testquestions)
            {
                foreach (var item2 in item.Answers)
                {
                    
                Console.WriteLine(item2.CheckedOrRanked);
                }
              
            }
            Console.WriteLine("tq done");

            using (var db = new Testverktyg.Context.TestverktygContext())
            {
                var tf = db.TestDefinitions.Where(td => td.Id == _testForm.TestDefinitionId).Include(q => q.Questions.Select(a => a.Answers)).FirstOrDefault();
                foreach (var item in tf.Questions)
                {
                    foreach (var itemasadas in item.Answers)
                    {

                    Console.WriteLine(itemasadas.CheckedOrRanked);
                    }
                }
            }
            //foreach (var item2 in _testForm.TestDefinition.Questions)
            //{
            //    Console.WriteLine(item2.Text);
            //}
            //Console.WriteLine("tf done");
            Console.WriteLine();
        }




        //var td = Repository<TestDefinition>.Instance.Get(testform.TestDefinitionId);

        //var questions = Repository<Question>.Instance.GetAll().Where(x => x.TestDefinitionId == td.Id).ToList();
        //var answers = Repository<Answer>.Instance.GetAll();
        ////MessageBox.Show(ta.TestDefinitions[0].Title);
        //foreach (var item in questions)
        //{
        //    TextBlock tb = new TextBlock();
        //    tb.Text = item.Text;
        //    testPageGrid.Children.Add(tb);
        //    var itemAnswers = answers.Where(x => x.QuestionId == item.Id).ToList();
        //    if (item.QuestionType == QuestionType.Open)
        //    {
        //        TextBox txxxxxb = new TextBox();
        //        txxxxxb.Text = "HellOo Its meee";
        //        txxxxxb.Width = 50;
        //        txxxxxb.Height = 50;
        //        testPageGrid.Children.Add(txxxxxb);
        //    }
        //    else
        //    {
        //        foreach (var item2 in itemAnswers)
        //        {
        //            if (item.QuestionType == QuestionType.Single)
        //            {
        //                RadioButton rb = new RadioButton();
        //                Label lb = new Label();
        //                lb.Content = item2.Text;
        //                testPageGrid.Children.Add(lb);
        //                testPageGrid.Children.Add(rb);
        //            }
        //            else if (item.QuestionType == QuestionType.Multi)
        //            {
        //                CheckBox cb = new CheckBox();
        //                Label lb = new Label();
        //                lb.Content = item2.Text;
        //                testPageGrid.Children.Add(lb);
        //                testPageGrid.Children.Add(cb);
        //            }

        //            else if (item.QuestionType == QuestionType.Ranked)
        //            {
        //                //do stuff
        //            }
        //        }
        //    }


        //}
    }
}


