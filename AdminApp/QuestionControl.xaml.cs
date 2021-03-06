﻿using System;
using System.Windows;
using System.Windows.Controls;
using Testverktyg.Model;
using Testverktyg.Repository;

namespace AdminApp {
    public class AnswerUIElement : Grid {
        public bool IsNotRemoved { get; set; }
        public Answer Answer { get; }
        public AnswerUIElement(Answer answer, Question question) {
            Answer = answer;
            IsNotRemoved = true;

            StackPanel skp = new StackPanel {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness { Bottom = 5, Left = 10 }
            };
            TextBox tbx_Answer = new TextBox {
                Width = 300,
                Text = answer.Text,
                Style = (Style)FindResource("Key_tbx_TextField")
            };
            Button btn_RemoveAnswer = new Button {
                Content = "-",
                HorizontalAlignment = HorizontalAlignment.Left
            };

            switch (question.QuestionType) {
                case QuestionType.Single:
                    RadioButton rdb = new RadioButton {
                        GroupName = question.Id.ToString(),
                        IsChecked = answer.CheckedOrRanked == 1
                    };
                    rdb.Checked += (s, e) => answer.CheckedOrRanked = 1;
                    rdb.Unchecked += (s, e) => answer.CheckedOrRanked = 0;
                    skp.Children.Add(rdb);
                    break;
                case QuestionType.Multi:
                    CheckBox cbx = new CheckBox { IsChecked = answer.CheckedOrRanked == 1 };
                    cbx.Checked += (s, e) => answer.CheckedOrRanked = 1;
                    cbx.Unchecked += (s, e) => answer.CheckedOrRanked = 0;
                    skp.Children.Add(cbx);
                    break;
            }

            skp.Children.Add(tbx_Answer);
            skp.Children.Add(btn_RemoveAnswer);
            Children.Add(skp);

            btn_RemoveAnswer.Click += (s, e) => {
                Visibility = Visibility.Collapsed;
                IsNotRemoved = false;
            };

            tbx_Answer.TextChanged += (s, e) =>
                Answer.Text = tbx_Answer.Text;
        }

        public void Save(int questionId) {
            Answer.QuestionId = questionId;
            var repo = Repository<Answer>.Instance;
            bool Exists = repo.Get(Answer.Id) != null;
            if (IsNotRemoved && Exists)
                repo.Update(Answer);
            else if (IsNotRemoved && !Exists)
                repo.Add(Answer);
            else if (!IsNotRemoved && Exists)
                repo.Delete(Answer);
        }
    }

    public partial class QuestionControl : UserControl {
        public bool IsNotRemoved { get; set; }
        public Question Question { get; }
        public QuestionControl(Question question) {
            InitializeComponent();
            Question = question;
            IsNotRemoved = true;
            btn_QuestionDelete.Click += (s, e) => {
                Visibility = Visibility.Collapsed;
                IsNotRemoved = false;
                foreach (AnswerUIElement element in skp_Answers.Children)
                    element.IsNotRemoved = false;
            };

            Action saveScore = () =>
                question.Score = int.Parse(((ComboBoxItem)cbx_QuestionScore.SelectedItem).Content.ToString());

            saveScore();
            cbx_QuestionScore.SelectionChanged += (s, e) => saveScore();

            tbx_QuestionText.Text = question.Text;
            tbx_QuestionText.TextChanged += (s, e) =>
                question.Text = tbx_QuestionText.Text;

            btn_AddAnswer.Click += (s, e) =>
                skp_Answers.Children.Add(new AnswerUIElement(new Answer(), Question));

            foreach (Answer answer in Repository<Answer>.Instance.GetAll()) {
                if (answer.QuestionId != question.Id)
                    continue;
                skp_Answers.Children.Add(new AnswerUIElement(answer, Question));
            }
        }

        public void Save(int testDefinitionId) {
            Question.TestDefinitionId = testDefinitionId;
            var repo = Repository<Question>.Instance;
            bool Exists = repo.Get(Question.Id) != null;
            if (IsNotRemoved && Exists)
                repo.Update(Question);
            else if (IsNotRemoved && !Exists)
                repo.Add(Question);
            else if (!IsNotRemoved && Exists)
                repo.Delete(Question);

            foreach (AnswerUIElement element in skp_Answers.Children)
                element.Save(Question.Id);
        }
    }
}
