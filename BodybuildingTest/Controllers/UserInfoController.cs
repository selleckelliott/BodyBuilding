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
    }
}
