using System;
using System.Collections.Generic;
namespace BodybuildingTest.Models.UserInformation
{
    public interface IUserInfoRepository
    {
        IEnumerable<UserInfo> GetAllUserInfo();
        UserInfo GetUserInfo(int id);
        void UpdateUserInfo(UserInfo userInfo);
        public void AddUser(UserInfo newUser);
    }
}
