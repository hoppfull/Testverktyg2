using System.Collections.Generic;

namespace Testverktyg.Model {
    public class StudentAccount : AbstractUser {
        public IList<TestForm> TestForms { get; set; }
    }
}
