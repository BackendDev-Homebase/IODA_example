namespace IODA.Data.Tests
{
    [TestClass]
    public class VisitorCountsTest
    {
        // only test of RemoveVisitorsWithMoreThan because all other operations inside VisitorCounts are a simple delegation
        // to an MS-API call and "Select Isn't Broken" (from "The Pragmatic Programmer" - 978-0201616224)

        [TestMethod]
        public void RemoveVisitorsWithMoreThan_OnlyOneVisitor_Remove_EmptyList()
        {
            // Arrange
            var visitorCounts = VisitorCounts.Create(new[] { "Foo 2" });

            // Act
            visitorCounts.RemoveVisitorsWithMoreThan(1);

            // Assert
            var visitors = visitorCounts.AllVisitors();
            visitors.Should().HaveCount(0);
        }

        [TestMethod]
        public void RemoveVisitorsWithMoreThan_OnlyOneVisitor_DontRemove_OneVisitor()
        {
            // Arrange
            var visitorCounts = VisitorCounts.Create(new[] { "Foo 2" });

            // Act
            visitorCounts.RemoveVisitorsWithMoreThan(2);

            // Assert
            var visitors = visitorCounts.AllVisitors();
            visitors.Should().HaveCount(1);
        }

        [TestMethod]
        public void RemoveVisitorsWithMoreThan_TwoVisitor_RemoveOneVisitor_EmtpyList()
        {
            // Arrange
            var visitorCounts = VisitorCounts.Create(new[] { "Foo 2", "Bar 1" });

            // Act
            visitorCounts.RemoveVisitorsWithMoreThan(1);

            // Assert
            var visitors = visitorCounts.AllVisitors();
            visitors.Should().HaveCount(1);
        }
    }
}