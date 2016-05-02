using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testverktyg.Model {
    public class StudentAccount : AbstractUser {
        public IList<TestForm> TestForms { get; set; }
        public StudentAccount(string name, string email, string password):base(name, email, password) {
            TestForms = new List<TestForm>();

        }
    }
}
