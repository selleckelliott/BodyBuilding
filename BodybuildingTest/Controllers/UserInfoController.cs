using BodybuildingTest.Models.Exercise;
using BodybuildingTest.Models.UserInformation;
using Microsoft.AspNetCore.Mvc;

namespace BodybuildingTest.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly IUserInfoRepository repo;
        public UserInfoController(IUserInfoRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var userInfo = repo.GetAllUserInfo();
            return View(userInfo);
        }
        public IActionResult ViewUserInfo(int id)
        {
            var userInfo = repo.GetUserInfo(id);
            return View(userInfo);
        }
        public IActionResult UpdateUserInfo(int id)
        {
            UserInfo userInfo = repo.GetUserInfo(id);
            if (userInfo == null)
            {
                return View("UserNotFound");
            }
            return View(userInfo);
        }
    }
}
