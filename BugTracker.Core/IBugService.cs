using System.Collections.Generic;

namespace BugTracker.Core
{
    public interface IBugService
    {
        void AddBug(Bug bug);
        List<Bug> GetAllBugs();
        bool UpdateStatus(int id, BugStatus newStatus);
    }
}