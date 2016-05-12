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

namespace AdminApp {
    public partial class DefineTestDefinition : Window {
        private TestDefinition TestDefinition { get; }
        private TeacherPage TeacherPage { get; }
        public DefineTestDefinition(TeacherPage teacherPage, TestDefinition testDefinition) {
            InitializeComponent();
            TestDefinition = testDefinition;
            TeacherPage = teacherPage;
            InitSubjectComboBox();

            teacherPage.IsEnabled = false;
            Closing += (s, e) => teacherPage.IsEnabled = true;

            foreach (Question question in Repository<Question>.Instance.GetAll()) {
                if (question.TestDefinitionId != TestDefinition.Id)
                    continue;
                skp_QuestionsList.Children.Add(new QuestionControl(question));
            }

            tbx_TestDefinitionTitle.Text = TestDefinition.Title;
            tbx_TestDefinitionTitle.TextChanged += (s, e) =>
                TestDefinition.Title = tbx_TestDefinitionTitle.Text;

            tbx_TestDefinitionParagraph.Text = TestDefinition.Paragraph;
            tbx_TestDefinitionParagraph.TextChanged += (s, e) =>
                TestDefinition.Paragraph = tbx_TestDefinitionParagraph.Text;

            btn_NewQuestion.Click += (s, e) =>
                skp_QuestionsList.Children.Add(CreateQuestionUI((QuestionType)((ComboBoxItem)cbx_QuestionType.SelectedItem).Tag));

            cbx_Subjects.SelectionChanged += (s, e) =>
                TestDefinition.SubjectId = ((Subject)cbx_Subjects.SelectedItem).Id;
        }
        
        private QuestionControl CreateQuestionUI(QuestionType questionType) {
            return new QuestionControl(new Question { QuestionType = questionType });
        }

        private void InitSubjectComboBox() {
            cbx_Subjects.ItemsSource = Repository<Subject>.Instance.GetAll();
            int i = 0;
            foreach (Subject subject in cbx_Subjects.ItemsSource) {
                if (subject.Id == TestDefinition.SubjectId) {
                    cbx_Subjects.SelectedIndex = i;
                    break;
                }
                i++;
            }
        }

        private void btn_Abort_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void btn_SaveTestDefinition_Click(object sender, RoutedEventArgs e) {
            TestDefinition.MaxScore = 0;
            foreach (QuestionControl qc in skp_QuestionsList.Children) {
                qc.Save(TestDefinition.Id);
                TestDefinition.MaxScore += qc.Question.Score;
            }
            Repository<TestDefinition>.Instance.Update(TestDefinition);
            TeacherPage.UpdateCreatedTestDefinitionsListView();
            Close();
        }
    }
}
