using LoanOrigination.Models.Account;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using Moq;
using LoanOrigination.Controllers;
using Microsoft.Extensions.Configuration;

namespace LoanTestPrj
{
    public class LoginTest
    {

        private readonly Mock<IUsersData> _mockDal;
        private readonly Mock<IConfiguration> _mockConfig;
        private readonly AccountController _controller;

        public LoginTest()
        {
            _mockDal = new Mock<IUsersData>();
            _mockConfig = new Mock<IConfiguration>();
            _controller = new AccountController(_mockDal.Object, _mockConfig.Object);
        }
        [Fact]
        public void Login_ValidCredentials_ReturnsOkResult()
        {
            // Arrange
            var username = "testuser";
            var pin = "1234";
            var hashedPin = Convert.ToBase64String(new HMACSHA256(Encoding.UTF8.GetBytes("secret")).ComputeHash(Encoding.UTF8.GetBytes(pin)));
            var user = new Users { Username = username, Pin = hashedPin, FirstName = "Test", LastName = "User" };

            _mockDal.Setup(d => d.GetUser(username)).Returns(user);
            //_mockDal.Setup(d => d.GetUser(username)).Returns(user);
            _mockConfig.Setup(c => c["secret"]).Returns("secret");
            _mockConfig.Setup(c => c["jwt:secretKey"]).Returns("abcdefghijklmnopqrstuvwxyz123456");
            _mockConfig.Setup(c => c["jwt:issuer"]).Returns("issuer");
            _mockConfig.Setup(c => c["jwt:audience"]).Returns("audience");

            // Act
            var result = _controller.Login(username, pin) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            var tokenResponse = result.Value;
            var token = tokenResponse.GetType().GetProperty("token")?.GetValue(tokenResponse, null);
            var firstName = tokenResponse.GetType().GetProperty("firstname")?.GetValue(tokenResponse, null);
            var lastName = tokenResponse.GetType().GetProperty("lastname")?.GetValue(tokenResponse, null);
            Assert.NotNull(token);
            Assert.Equal("Test", firstName);
            Assert.Equal("User", lastName);
        }

        [Fact]
        public void Login_InvalidPin_ReturnsBadRequest()
        {
            // Arrange
            var username = "testuser";
            var pin = "wrongpin";
            var hashedPin = Convert.ToBase64String(new HMACSHA256(Encoding.UTF8.GetBytes("secret")).ComputeHash(Encoding.UTF8.GetBytes("1234")));
            var user = new Users { Username = username, Pin = hashedPin };

            _mockDal.Setup(d => d.GetUser(username)).Returns(user);
            _mockConfig.Setup(c => c["secret"]).Returns("secret");

            // Act
            var result = _controller.Login(username, pin);

            // Assert
            Assert.NotNull(result);
            var errorResponse = Assert.IsType<BadRequestObjectResult>(result);
            var objval = errorResponse.Value;
            var msg = objval.GetType().GetProperty("msg")?.GetValue(objval, null);
            Assert.Equal("Invalid pin", msg);
        }
    }
}