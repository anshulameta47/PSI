using Com.Sapient.Data;
using Com.Sapient.Helpers;
using Com.Sapient.Models;
using Com.Sapient.Services;
using Com.Sapient.Services.RedisService;
using Com.Sapient.Services.UserService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

 

 

namespace UserServiceTest
{
    [TestClass]
    public class UserServiceTest
    {
        //Only Add tests for UserService class here
        private DataContext _context;
        private UserService _userService;
        private Mock<IUserService> _userServiceMock;
        private IRedisService _redisService;
        private DbContext _dbcontext;

 
        private Mock<IRedisService> _redisServiceMock;
        private Mock<IOptions<AppSettings>> _appSettingsMock;
        private Mock<DbContext> _dbContextMock;
        private Mock<IDatabase> database = new Mock<IDatabase>();

        public object Gender { get; private set; }

        //gets called before every test
        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            //var mock = new Mock<IGetDataRepository>();
            //mock.Setup(p => p.GetNameById(1)).Returns("Jignesh");
            //HomeController home = new HomeController(mock.Object);
            //string result = home.GetNameById(1);
            //Assert.AreEqual("Jignesh", result);

 

 

            _redisServiceMock = new Mock<IRedisService>();
            _appSettingsMock = new Mock<IOptions<AppSettings>>();
            _userServiceMock = new Mock<IUserService>();
            _redisService = new RedisService();
            _context = new DataContext(options);
            _context.Database.EnsureCreated();
            SeedContext(_context);
            _userService = new UserService(_appSettingsMock.Object, _context, _redisServiceMock.Object);
            _dbContextMock = new Mock<DbContext>();
        }
        [TestMethod]
        public async Task GetAllUsers_ShouldReturnAllValues()
        {
            //Act
            var result = await _userService.GetAll();
            //Assert
            Assert.IsNotNull(result);
        }

 

 

        [TestMethod]
        public void GetByEmail_ShouldReturnTrue_WhenFirstNameMatches()
        {
            var user = new UserAccount { Email = "john@gmail.com", FirstName = "John", LastName = "Doe", IsdCode = 91, Phone = 838292832, Password = "temppass123" };
            //Act
            var result = _userService.GetByEmail("john@gmail.com");
            //Assert
            Assert.AreEqual(user.FirstName, result.FirstName);
        }

 

 

        [TestMethod]
        public void TestLogout_ToeknShouldBeNil_AfetrLogout()
        {
            var user = new UserAccount { Email = "john@gmail.com", FirstName = "John", LastName = "Doe", IsdCode = 91, Phone = 838292832, Password = "temppass123" };
            //Setup
          var token= _userServiceMock.Setup(x => x.GenerateJwtToken(user)).Returns("EYpOpkOf9VXCVDXA").ToString();
            // var token = _userService.generateJwtToken(user);
            _redisServiceMock.Setup(x => x.InsertData(database,user.Email,token)
            
            //  var conn = _redisService.RedisConnection();
          //  _redisService.InsertData(conn, user.Email, token);
 
          //  _userService.Logout(token);
            //Assert
            
            Assert.IsTrue(!_userService.CheckToken(token));
        }
        [TestMethod]
        public async Task TestDeleteUser__UserShouldBeDeleted()
        {
            var user = new UserAccount { Email = "john@gmail.com", FirstName = "John", LastName = "Doe", IsdCode = 91, Phone = 838292832, Password = "temppass123" };
            //Act
            var token = _userService.GenerateJwtToken(user);
            //Assert
            var status = await _userService.DeleteUser(token, user.Password);
            Assert.IsTrue(status);
        }
        [TestMethod]
        public async Task TestDeactivateUser__UserShouldBeDeActivated()
        {
            var user = new UserAccount { Email = "john@gmail.com", FirstName = "John", LastName = "Doe", IsdCode = 91, Phone = 838292832, Password = "temppass123" };
            //Act
            var token = _userService.GenerateJwtToken(user);
            //Assert
            var status = await _userService.DeactivateUser(token, user.Password);
            Assert.IsTrue(status);
        }

 

        //[TestMethod]
        //public async Task GetUserByEmail_ShouldReturnNull_WhenUserDoesNotExist()
        //{
        //    var result = await _userService.GetUserByEmail("john123@gmail.com");
        //    Assert.IsNull(result);
        //}
        //[TestCleanup]
        //public void Cleanup()
        //{
        //    _context.Database.EnsureDeleted();
        //    _context.Dispose();
        //}

 

 

        private void SeedContext(DataContext context)
        {
            var users = new[]
            {
                new UserAccount{Email="john@gmail.com",FirstName="John",LastName="Doe",IsdCode=91,Phone=838292832,Password="temppass123"},
                new UserAccount{Email="jane@gmail.com",FirstName="Jane",LastName="Doe",IsdCode=92,Phone=234292232,Password="psdfhsdf230"},
                new UserAccount{Email="dann7@yahoo.com",FirstName="Danny",LastName="Smith",IsdCode=1,Phone=645392832,Password="@#kjsdf8ks"},
                new UserAccount{Email="sling@gmail.com",FirstName="Sling",LastName="Shot",IsdCode=77,Phone=876576832,Password="SKDjf123"}
            };
            context.UserAccounts.AddRange(users);
            context.SaveChanges();
        }
    }
}