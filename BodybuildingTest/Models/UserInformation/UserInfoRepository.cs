using Dapper;
using System.Data;

namespace BodybuildingTest.Models.UserInformation
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly IDbConnection _conn;
        public UserInfoRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<UserInfo> GetAllUserInfo()
        {
            return _conn.Query<UserInfo>("SELECT * FROM USERINFO;");
        }
    }
}
