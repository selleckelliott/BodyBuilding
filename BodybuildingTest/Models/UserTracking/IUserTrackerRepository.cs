using System;
using System.Collections.Generic;

namespace BodybuildingTest.Models.UserTracking
{
    public interface IUserTrackerRepository
    {
        IEnumerable<UserTracker> GetAllTrackers();
        UserTracker GetTrackers(int id); //used to retreive user exercise info from database by TrackerID
    }
}
