namespace LiveDocs.Diagrams.Examples.AcceptanceTests
{
    using Xunit;

    public class TestFlows
    {
        [Fact]
        public void Test()
        {
            var loginFlow = new LoginFlow().Build();            
        }
    }
}
