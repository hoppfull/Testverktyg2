using System.Data.Entity;
using Testverktyg.Model;

namespace Testverktyg.Context {
    public class TestverktygContext : DbContext {
        public DbSet<AdminAccount> AdminAccounts { get; set; }
        public DbSet<StudentAccount> StudentAccounts { get; set; }
        public DbSet<TeacherAccount> TeacherAccounts { get; set; }
        public DbSet<TestDefinition> TestDefinitions { get; set; }
        public DbSet<TestForm> TestForms { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnsweredQuestion> AnsweredQuestions { get; set; }

        public TestverktygContext():base("TestverktygDB") {

        }
    }
}
