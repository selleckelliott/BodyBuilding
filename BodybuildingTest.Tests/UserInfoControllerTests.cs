using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Microsoft.AspNetCore.Mvc;
using BodybuildingTest.Controllers;
using BodybuildingTest.Models.UserInformation;
using System.Collections.Generic;
using Org.BouncyCastle.Security;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace BodybuildingTestTests
{
    [TestClass]
    public class UserInfoControllerTests
    {
        private Mock<IUserInfoRepository> _mockRepo;
        private UserInfoController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockRepo = new Mock<IUserInfoRepository>();
            _controller = new UserInfoController(_mockRepo.Object);
        }
        [TestMethod]
        public void Index_ReturnsViewResult_WithListOfUserInfo()
        {
            // Arrange
            var mockUserInfo = new List<UserInfo>
            {
                new UserInfo
                {
                    Username = "zxc",
                    Email = "zxc@zxc.com",
                    Password = "password",
                    Create_Time = new DateTime(2024, 07, 14),
                    UserID = 555,
                    FirstName = "Cathy",
                    LastName = "Wallace",
                    Most_Recent_Workout = new DateTime(2024, 07, 14)
                },
                new UserInfo
                {
                    Username = "qwee",
                    Email = "qwee@zxc.com",
                    Password = "password",
                    Create_Time = new DateTime(2024,07,14),
                    UserID = 456,
                    FirstName = "Jeremy",
                    LastName = "Armstrong",
                    Most_Recent_Workout = new DateTime(2024, 07, 14)
                },
            };
            _mockRepo.Setup(repo => repo.GetAllUserInfo()).Returns(mockUserInfo);

            // Act
            var result = _controller.Index();

            // Assert
            var viewResult = result as ViewResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(viewResult, "Result is not of type ViewResult");

            var model = viewResult?.Model as List<UserInfo>;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model, "Model is not of type List<UserInfo>");

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(2, model.Count);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Cathy", model[0].FirstName);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Jeremy", model[1].FirstName);
        }
        [TestMethod]
        public void ViewUserInfo_ReturnsViewResult_WithUserInfo()
        {
            //Arrange
            var userInfoId = 555;
            var mockUserInfo = new UserInfo
            {
                Username = "zxc",
                Email = "zxc@zxc.com",
                Password = "password",
                Create_Time = new DateTime(2024, 7, 14),
                UserID = userInfoId,
                FirstName = "Cathy",
                LastName = "Wallace",
                Most_Recent_Workout = new DateTime(2024, 7, 14)
            };
            _mockRepo.Setup(repo => repo.GetUserInfo(userInfoId)).Returns(mockUserInfo);

            // Act
            var result = _controller.ViewUserInfo(userInfoId);

            // Assert
            var viewResult = result as ViewResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(viewResult, "Result is not of type ViewResult");

            var model = viewResult?.Model as UserInfo;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model, "Model is not of type UserInfo");

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Cathy", model.FirstName);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Wallace", model.LastName);
        }
        [TestMethod]
        public void UpdateUserInfo_ReturnsViewResult_UserNotFound()
        {
            //Arrange

            int nonExistentUserID = 999;
            _mockRepo.Setup(repo => repo.GetUserInfo(nonExistentUserID)).Returns((UserInfo)null);

            // Act
            var result = _controller.UpdateUserInfo(nonExistentUserID);

            // Assert
            var viewResult = result as ViewResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(viewResult, "Result is not of type ViewResult");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("UserNotFound", viewResult.ViewName, "The view name returned is not 'UserNotFound'");
        }
        [TestMethod]
        public void UpdateUserInfoToDatabase_UpdatesUserInfo_ReturnsRedirectResult()
        {
            // Arrange
            var userInfoId = 555;
            var originalUserInfo = new UserInfo
            {
                Username = "zxc",
                Email = "zxc@zxc.com",
                Password = "password",
                Create_Time = new DateTime(2024, 7, 14),
                UserID = userInfoId,
                FirstName = "Cathy",
                LastName = "Wallace",
                Most_Recent_Workout = new DateTime(2024, 7, 14)
            };

            var updatedUserInfo = new UserInfo
            {
                Username = "bnm",
                Email = "zxc@zxc.com",
                Password = "updatedpassword",
                Create_Time = new DateTime(2024, 7, 14),
                UserID = userInfoId,
                FirstName = "Cathy",
                LastName = "Wallace",
                Most_Recent_Workout = new DateTime(2024, 7, 14)
            };
            //Updating user information
            _mockRepo.Setup(repo => repo.UpdateUserInfo(It.Is<UserInfo>(u =>
                u.UserID == updatedUserInfo.UserID &&
                u.Username == updatedUserInfo.Username &&
                u.Password == updatedUserInfo.Password
            ))).Verifiable();

            // Act
            var result = _controller.UpdateUserInfoToDatabase(updatedUserInfo);

            // Assert
            var redirectResult = result as RedirectToActionResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(redirectResult, "Result is not of type RedirectToActionResult");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("ViewUserInfo", redirectResult.ActionName);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(userInfoId, redirectResult.RouteValues["id"]);

            // Verify that the UpdateUserInfo method was called with the updated information
            _mockRepo.Verify();
        }
        [TestMethod]
        public void NewUser_ReturnsRedirectToAction_Index()
        {
            // Arrange
            var newUser = new UserInfo
            {
                Username = "Tyr",
                Email = "tyr@zxc.com",
                Password = "password",
                Create_Time = new DateTime(2024, 08, 01),
                UserID = 925,
                FirstName = "Tyr",
                LastName = "Odinson",
                Most_Recent_Workout = new DateTime(2024, 08, 01)
            };

            // Setup the mock repository to expect a call to AddUser and do nothing on success
            _mockRepo.Setup(repo => repo.AddUser(It.IsAny<UserInfo>()));

            // Act
            var result = _controller.NewUser(newUser);

            // Assert
            var redirectToActionResult = result as RedirectToActionResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(redirectToActionResult, "Result is not of type RedirectToActionResult");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Index", redirectToActionResult.ActionName, "The action name returned is not 'Index'");
        }
        [TestMethod]
        public void InsertUser_ReturnsViewResult_WithUserInfo()
        {
            // Arrange
            var expectedUser = new UserInfo
            {
                Username = "newuser",
                Email = "newuser@example.com",
                Password = "newpassword",
                Create_Time = new DateTime(2024, 08, 01),
                UserID = 123,
                FirstName = "New",
                LastName = "User",
                Most_Recent_Workout = new DateTime(2024, 08, 01)
            };

            // Set up the mock repository to return the expected user
            _mockRepo.Setup(repo => repo.AssignNewUser()).Returns(expectedUser);

            // Act
            var result = _controller.InsertUser(new UserInfo());

            // Assert
            var viewResult = result as ViewResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(viewResult, "Result is not of type ViewResult");

            var model = viewResult?.Model as UserInfo;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model, "Model is not of type UserInfo");

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedUser.Username, model.Username);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedUser.Email, model.Email);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedUser.Password, model.Password);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedUser.Create_Time, model.Create_Time);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedUser.UserID, model.UserID);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedUser.FirstName, model.FirstName);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedUser.LastName, model.LastName);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedUser.Most_Recent_Workout, model.Most_Recent_Workout);
        }
        [TestMethod]
        public void DeleteUser_CallsDeleteUser_AndRedirectsToIndex()
        {
            // Arrange
            var userToDelete = new UserInfo
            {
                Username = "deleteuser",
                Email = "deleteuser@example.com",
                Password = "deletepassword",
                Create_Time = new DateTime(2024, 08, 01),
                UserID = 789,
                FirstName = "Delete",
                LastName = "User",
                Most_Recent_Workout = new DateTime(2024, 08, 01)
            };

            // Set up the mock repository to expect a call to DeleteUser with the specific userInfo
            _mockRepo.Setup(repo => repo.DeleteUser(userToDelete));

            // Act
            var result = _controller.DeleteUser(userToDelete);

            // Assert
            // Verify that DeleteUser was called with the correct UserInfo object
            _mockRepo.Verify(repo => repo.DeleteUser(userToDelete), Times.Once);

            // Verify that the result is a RedirectToActionResult
            var redirectResult = result as RedirectToActionResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(redirectResult, "Result is not of type RedirectToActionResult");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Index", redirectResult.ActionName, "The action name returned is not 'Index'");
        }
    }
}
