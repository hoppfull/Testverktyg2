using System.Data.Entity;

namespace Testverktyg {
    public class MyDatabase : DbContext {
        public DbSet<MyTable> MyTables { get; set; }
    }
}
