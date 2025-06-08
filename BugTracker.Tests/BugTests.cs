using BugTracker.Core;

using Xunit;

namespace BugTracker.Tests
{

    public class BugTests
    {
        [Fact]
        public void Bug_DefaultPriority_ShouldBeMedium()
        {
            var bug = new Bug("Bug title", "Bug description");
            Assert.Equal(BugPriority.Medium, bug.Priority);
        }

        [Fact]
        public void Bug_CustomPriority_ShouldSetCorrectly()
        {
            var bug = new Bug("Bug title", "Bug description", BugPriority.High);
            Assert.Equal(BugPriority.High, bug.Priority);
        }

        [Fact]
        public void Bug_PriorityCanBeUpdated()
        {
            var bug = new Bug("Bug title", "Bug description");
            bug.Priority = BugPriority.Low;
            Assert.Equal(BugPriority.Low, bug.Priority);
        }


        [Fact]
        public void CanAddAttachmentUrl()
        {
            var bug = new Bug();
            bug.AttachmentUrl = "http://example.com/image.png";
            Assert.Equal("http://example.com/image.png", bug.AttachmentUrl);
        }

        // TODO: Add test to verify default value of AssignedToDeveloper is null

        // TODO: Add test to verify AssignedToDeveloper can be assigned and retrieved correctly
    }
}
