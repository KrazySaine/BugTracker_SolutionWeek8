
namespace BugTracker.Core
{
    public enum BugStatus
    {
        Open,
        InProgress,
        Closed
    }

    public enum BugPriority
    {
        Low,
        Medium,
        High
    }

    public class Bug
    {
        private static int _idSeed = 1;
        public int Id { get; }
        public string Title { get; }
        public string Description { get; set; }
        public BugStatus Status { get; private set; }
        public string AssignedToDeveloper { get; set; }
        public string? AttachmentUrl { get; set; }

        public BugPriority Priority { get; set; }  // New property

        public Bug(string title, string description, BugPriority priority = BugPriority.Medium)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Bug title cannot be empty or whitespace.", nameof(title));
            }

            Title = title;
            Description = description;
            Status = BugStatus.Open;
            Priority = priority;
            Id = _idSeed++;
        }

        public void UpdateStatus(BugStatus newStatus)
        {
            if (newStatus == Status)
            {
                return;
            }

            Status = newStatus;
        }
    }
}
