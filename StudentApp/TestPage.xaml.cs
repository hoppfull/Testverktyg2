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

namespace StudentApp
{
    /// <summary>
    /// Interaction logic for TestPage.xaml
    /// </summary>
    public partial class TestPage : Window
    {
        public TestPage(TestForm testform, StudentAccount student)
        {
            InitializeComponent();
            var td = Repository<TestDefinition>.Instance.Get(testform.TestDefinitionId);

            var questions = Repository<Question>.Instance.GetAll().Where(x => x.TestDefinitionId == td.Id).ToList();
            var answers = Repository<Answer>.Instance.GetAll();
            //MessageBox.Show(ta.TestDefinitions[0].Title);
            foreach (var item in questions)
            {
                TextBlock tb = new TextBlock();
                tb.Text = item.Text;
                testPageGrid.Children.Add(tb);
                var itemAnswers = answers.Where(x => x.QuestionId == item.Id).ToList();
                if (item.QuestionType == QuestionType.Open)
                {
                    TextBox txxxxxb = new TextBox();
                    txxxxxb.Text = "HellOo Its meee";
                    txxxxxb.Width = 50;
                    txxxxxb.Height = 50;
                    testPageGrid.Children.Add(txxxxxb);
                }
                else
                {
                    foreach (var item2 in itemAnswers)
                    {
                        if (item.QuestionType == QuestionType.Single)
                        {
                            RadioButton rb = new RadioButton();
                            Label lb = new Label();
                            lb.Content = item2.Text;
                            testPageGrid.Children.Add(lb);
                            testPageGrid.Children.Add(rb);
                        }
                        else if (item.QuestionType == QuestionType.Multi)
                        {
                            CheckBox cb = new CheckBox();
                            Label lb = new Label();
                            lb.Content = item2.Text;
                            testPageGrid.Children.Add(lb);
                            testPageGrid.Children.Add(cb);
                        }

                        else if (item.QuestionType == QuestionType.Ranked)
                        {
                            //do stuff
                        }
                    }
                }


            }
        }
    }
}
