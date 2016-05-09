using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testverktyg.Model {
    public class Answer {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public int CheckedOrRanked { get; set; }
        public int? QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
        public int AnswerQuestionId { get; set; }
        [ForeignKey("AnswerdQuestonId")]
        public AnsweredQuestion AnswerdQuestion { get; set; }

    }
}
