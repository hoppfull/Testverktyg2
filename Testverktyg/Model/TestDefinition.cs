using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public Subject Subject { get; set; }
        public TestDefinitionState TestDefinitionState { get; set; }
        public bool IsNotRemoved { get; set; }
        public IList<Question> Questions { get; set; }
        public TestDefinition() {
            TestDefinitionState = TestDefinitionState.Created;
            IsNotRemoved = true;
            MaxScore = 0;
        }
    }
}
