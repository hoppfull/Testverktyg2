using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testverktyg.Model {
    public enum QuestionType {
        Single, Multi, Ranked, Open
    }
    public class Question {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public int Score { get; set; }
        public QuestionType QuestionType { get; set; }
        public IList<Answer> Answers { get; set; }
        public Question(QuestionType questionType, string text = "", int score = 1) {
            Text = text;
            Score = score;
            QuestionType = questionType;
            Answers = new List<Answer>();
        }
    }
}
