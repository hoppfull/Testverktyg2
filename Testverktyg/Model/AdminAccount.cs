using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testverktyg.Model {
    public class AdminAccount : AbstractUser {
        public IList<TestDefinition> TestDefinitions { get; set; }
        public AdminAccount(string name, string email, string password):base(name, email, password) {
        }
    }
}
