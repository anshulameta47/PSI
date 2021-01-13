using Castle.Core.Configuration;
using Com.Sapient.Controllers.V1;
using Com.Sapient.Services;
using Com.Sapient.Services.ActivationTokenService;
using Com.Sapient.Services.RedisService;
using Login.Contracts.V1.Response;
using Login.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LoginControllerTest
{
    [TestClass]
    public class LoginControllerTest
    {
        private  Mock<IUserService> _userServiceMock;
        private  Mock<IActivationTokenService> _passwordResetTokenServiceMock;
        private  Mock<IRedisService> _redisServiceMock;
        private  Mock<IConfigurationRoot> _configurationMock;

        private LoginController _loginController;

        [TestInitialize]
        public void Setup()
        {
            _userServiceMock = new Mock<IUserService>();
            _passwordResetTokenServiceMock = new Mock<IActivationTokenService>();
            _redisServiceMock = new Mock<IRedisService>();
            _configurationMock = new Mock<IConfigurationRoot>();
            _loginController = new LoginController(_userServiceMock.Object, _passwordResetTokenServiceMock.Object, _redisServiceMock.Object, _configurationMock.Object);
        }
        [TestMethod]
        public void AuthenticateUser_ShouldReturnOK_WhenCredentialsCorrect()
        {
            //UserAccount user = new UserAccount { Email = "test3@gmail.com", Password = "test", IsActive = true, FirstName = "raj", LastName = "kapoor" };
            //AuthenticateRequest request = new AuthenticateRequest { Email = "test3@gmail.com", Password = "test" };
            //AuthenticateResponse response = new AuthenticateResponse(user,"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InRlc3QzQGd" +
            //                                "tYWlsLmNvbSIsIm5iZiI6MTYwMjgwNDQ4NywiZXhwIjoxNjAzNDA5Mjg3LCJpYXQiOjE2MDI4MDQ0ODd9.J2F6rcym4l7nxodqMZg4ItgTr3w4BSwJSPcu4QHvQo8" );
            //_userServiceMock.Setup(d => d.Authenticate(It.Is<AuthenticateRequest>(s => Equals(request)))).Returns(()=>response);
            ////Act
            //var result =  _loginController.Authenticate(request);
            ////Assert
            //Assert.IsInstanceOfType(result, typeof(OkObjectResult));

        }
    }
}
