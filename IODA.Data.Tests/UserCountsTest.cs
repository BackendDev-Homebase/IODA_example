namespace IODA.Data.Tests
{
    [TestClass]
    public class UserCountsTest
    {
        // only test of RemoveUsersWithMoreThan because all other operations inside UserCounts is a simple delegation
        // to an MS-API call and "Select Isn't Broken" (from "The Pragmatic Programmer" - 978-0201616224)

        [TestMethod]
        public void RemoveUsersWithMoreThan_OnlyOneUser_Remove_EmptyList()
        {
            // Arrange
            var userCounts = UserCounts.Create(new[] { "Foo 2" });

            // Act
            userCounts.RemoveUsersWithMoreThan(1);

            // Assert
            var users = userCounts.AllUsers();
            users.Should().HaveCount(0);
        }

        [TestMethod]
        public void RemoveUsersWithMoreThan_OnlyOneUser_DontRemove_OneUser()
        {
            // Arrange
            var userCounts = UserCounts.Create(new[] { "Foo 2" });

            // Act
            userCounts.RemoveUsersWithMoreThan(2);

            // Assert
            var users = userCounts.AllUsers();
            users.Should().HaveCount(1);
        }

        [TestMethod]
        public void RemoveUsersWithMoreThan_TwoUser_RemoveOneUser_EmtpyList()
        {
            // Arrange
            var userCounts = UserCounts.Create(new[] { "Foo 2", "Bar 1" });

            // Act
            userCounts.RemoveUsersWithMoreThan(1);

            // Assert
            var users = userCounts.AllUsers();
            users.Should().HaveCount(1);
        }
    }
}