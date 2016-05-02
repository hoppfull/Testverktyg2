using System.Collections.Generic;

namespace Testverktyg.Model {
    public class TeacherAccount : AbstractUser {
        public IList<TestDefinition> TestDefinitions { get; set; }
        public TeacherAccount(string name, string email, string password):base(name, email, password) {
            TestDefinitions = new List<TestDefinition>();

        }
    }
}
