using System;
using System.Collections.Generic;

namespace BodybuildingTest.Models
{
    public interface IUserTrackerRepository
    {
        IEnumerable<UserTracker> GetAllTrackers();
        UserTracker GetTrackers(int id); //used to retreive user exercise info from database by TrackerID
    }
}
