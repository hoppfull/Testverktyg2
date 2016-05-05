using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
    }
}
