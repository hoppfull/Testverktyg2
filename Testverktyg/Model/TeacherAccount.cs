using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testverktyg.Model {
    public class TeacherAccount {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsNotRemoved { get; set; }
        public IList<TestDefinition> TestDefinitions { get; set; }
    }
}
