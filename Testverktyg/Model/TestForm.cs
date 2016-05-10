using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testverktyg.Model {
    public enum GradeType {
        G, VG, IG
    }
    public class TestForm {
        [Key]
        public int Id { get; set; }
        public int Score { get; set; }
        public bool IsCompleted { get; set; }
        public int TimeLimit { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishedDate { get; set; }
        public DateTime FinalDate { get; set; }
        public int TestDefinitionId { get; set; }
        [ForeignKey("TestDefinitionId")]
        public TestDefinition TestDefinition { get; set; }
        public int StudentAccountId { get; set; }
        [ForeignKey("StudentAccountId")]
        public StudentAccount StudentAccount { get; set; }
        public TestForm() {
            IsCompleted = false;
        }
    }
}
