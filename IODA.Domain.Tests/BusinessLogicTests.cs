namespace IODA.Domain.Tests
{
    [TestClass]
    public class BusinessLogicTests
    {
        // only Test the Operations
        // so only tests for the internal GetGreetingMessage

        [DataTestMethod]
        [DataRow(0, "Hello, Dieter!")]
        [DataRow(1, "Welcome back, Dieter!")]
        [DataRow(2, "Welcome back, Dieter!")]
        [DataRow(3, "Welcome back, Dieter!")]
        [DataRow(4, "Hello, my good friend Dieter!")]
        [DataRow(99, "Hello, my good friend Dieter!")]
        public void GetGreetingMessage(int count, string expected)
        {
            // Act
            var message = BusinessLogic.GetGreetingMessage(count, "Dieter");

            // Assert
            message.Should().Be(expected);
        }
    }
}