using System.Collections.Generic;

namespace Testverktyg.Model {
    public class TeacherAccount : AbstractUser {
        public IList<TestDefinition> TestDefinitions { get; set; }
    }
}
