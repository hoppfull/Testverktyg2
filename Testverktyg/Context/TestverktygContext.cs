using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Model;

namespace Testverktyg.Context {
    public class TestverktygContext : DbContext {
        public DbSet<AdminAccount> AdminAccounts { get; set; }
    }
}
