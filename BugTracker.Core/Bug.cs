
namespace BugTracker.Core
{
    public class Bug
    {
        private static int _idSeed = 1;
        public int Id { get; }
        public string Title { get; }
        public string Description { get; set; }
        public BugStatus Status { get; private set; }
        public string AssignedToDeveloper { get; set; }  // New property

        public string? AttachmentUrl { get; set; }

        public Bug(string title, string description)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Bug title cannot be empty or whitespace.", nameof(title));
            }

            Title = title;
            Description = description;
            Status = BugStatus.Open;
            Id = _idSeed++;
        }

        public void UpdateStatus(BugStatus newStatus)
        {
            // Introduced bug: allows reopening a Closed bug (should be disallowed)
            if (newStatus == Status)
            {
                return;
            }

            Status = newStatus;
        }
    }
}
