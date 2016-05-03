namespace Testverktyg.Model {
    public class AdminAccount : AbstractUser {
        public IList<TestDefinition> TestDefinitions { get; set; }
    }
}
