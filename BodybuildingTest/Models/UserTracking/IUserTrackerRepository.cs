using System;
using System.Collections.Generic;

namespace BodybuildingTest.Models.UserTracking
{
    public interface IUserTrackerRepository
    {
        public IEnumerable<UserTracker> GetAllTrackers();
        UserTracker GetTrackers(int id); //used to retreive user exercise info from database by TrackerID
        void UpdateUserTracker (UserTracker userTracker);
        public void InsertUserTracker (UserTracker userTracker);
        public UserTracker AssignNewUserTracker();
    }
}
