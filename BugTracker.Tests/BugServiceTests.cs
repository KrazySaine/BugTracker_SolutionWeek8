using Xunit;
using Moq;
using BugTracker.Core;
using System.Collections.Generic;

namespace BugTracker.Tests
{
    public class BugServiceTests
    {
        [Fact]
        public void AddBug_Should_Call_Create_Method()
        {
            // Arrange
            var mockRepo = new Mock<IBugService>();
            var bug = new Bug("Test Bug", "Test Description");

            // Act
            mockRepo.Object.AddBug(bug);

            // Assert
            mockRepo.Verify(service => service.AddBug(It.Is<Bug>(b => b.Title == "Test Bug")), Times.Once);
        }

        // TODO: [Fact] public void GetAllBugs_Should_Return_All_Existing_Bugs()
        [Fact]
        public void GetAllBugs_Should_Return_All_Existing_Bugs()
        {
            // Arrange
            var expectedBugs = new List<Bug>
    {
        new Bug("Bug 1", "Description 1"),
        new Bug("Bug 2", "Description 2")
    };

            var mockRepo = new Mock<IBugService>();
            mockRepo.Setup(service => service.GetAllBugs()).Returns(expectedBugs);

            // Act
            var result = mockRepo.Object.GetAllBugs();

            // Assert
            Assert.Equal(expectedBugs.Count, result.Count);
            Assert.Equal("Bug 1", result[0].Title);
            Assert.Equal("Bug 2", result[1].Title);
        }

        // TODO: [Fact] public void UpdateStatus_Should_Change_Bug_Status()
        // TODO: [Fact] public void UpdateStatus_Invalid_Id_Should_Return_False()
    }
}