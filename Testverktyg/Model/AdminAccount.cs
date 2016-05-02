using System.Collections.Generic;

namespace Testverktyg.Model {
    public class AdminAccount : AbstractUser {
        public IList<TestDefinition> TestDefinitions { get; set; }
        public AdminAccount(string name, string email, string password):base(name, email, password) {
        }
    }
}
