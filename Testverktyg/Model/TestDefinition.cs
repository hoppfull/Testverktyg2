using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testverktyg.Model {
    public enum TestDefinitionState {
        Created, Sent, Returned, Validated
    }
    public class TestDefinition {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Paragraph { get; set; }
        public int MaxScore { get; set; }
        public TestDefinitionState TestDefinitionState { get; set; }
        public bool IsNotRemoved { get; set; }
        public IList<Question> Questions { get; set; }
        
        //Foreign keys:
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
        public int TeacherAccountId { get; set; }
        [ForeignKey("TeacherAccountId")]
        public TeacherAccount TeacherAccount { get; set; }
        
        public TestDefinition() {
            TestDefinitionState = TestDefinitionState.Created;
            IsNotRemoved = true;
            MaxScore = 0;
        }
    }
}
