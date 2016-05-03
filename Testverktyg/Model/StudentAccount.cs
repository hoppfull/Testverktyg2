using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testverktyg.Model {
    public class StudentAccount : AbstractUser {
        public IList<TestForm> TestForms { get; set; }
    }
}
