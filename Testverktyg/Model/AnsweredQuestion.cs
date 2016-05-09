using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testverktyg.Model {
    public class AnsweredQuestion {
        [Key]
        public int Id { get; set; }
        public IList<Answer> Answers { get; set; }
        public Question Question { get; set; }
        public int? TestFormId { get; set; }
        [ForeignKey("TestFormId")]
        public TestForm TestForm { get; set; }
    }
}
