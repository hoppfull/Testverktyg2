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

namespace AdminApp {
    public partial class DefineTestDefinition : Window {
        private TestDefinition TestDefinition { get; }
        public DefineTestDefinition(TeacherPage parentWindow, TestDefinition testDefinition) {
            InitializeComponent();
            TestDefinition = testDefinition;
            parentWindow.IsEnabled = false;
            Closing += (s, e) => parentWindow.IsEnabled = true;
            icl_QuestionsList.ItemsSource = new List<Button> {
            };
        }
        
        private QuestionControl CreateQuestionUI(string text, int score) {
            QuestionControl qc = new QuestionControl();
        }
    }
}
