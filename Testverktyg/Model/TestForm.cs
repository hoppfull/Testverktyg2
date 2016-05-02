using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testverktyg.Model {
    public class TestForm {
        [Key]
        public int Id { get; set; }
        public int Score { get; set; }
        public bool IsCompleted { get; set; }
        public int TimeLimit { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishedDate { get; set; }
        public DateTime FinalDate { get; set; }
        public IList<AnsweredQuestion> AnsweredQuestion { get; set; }
    }
}

