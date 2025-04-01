using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanOrigination.Controllers;
using LoanOrigination.Models.CustomerSearch;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace LoanTestPrj
{
    public class FindCustomerTest
    {
        [Fact]
        public void GetCustomer_ReturnsOkResult_WhenCustomersExist()
        {
            // Arrange
            var mockDal = new Mock<ICustomerDataAccess>();
            var customers = new List<Customer>
        {
            new Customer {
                Id = 1,
                FirstName = "abc",
                LastName = "abc",
                Date_of_Birth = new DateOnly(2002, 10, 09),
                Phone = "1234567890",
                Email = "abc@123",
                Address = "abc",
                Company_Name = "abc",
                Salary = 123,
                Net_Income = 123,
                Last_salary_date = new DateOnly(1990, 01, 02)
            },
            new Customer {
                Id = 3,
                FirstName = "abc",
                LastName = "abc",
                Date_of_Birth = new DateOnly(2002, 10, 09),
                Phone = "1234567890",
                Email = "xyz",
                Address = "xyz",
                Company_Name = "xyz",
                Salary = 1230,
                Net_Income = 1230,
                Last_salary_date = new DateOnly(2025, 03, 26)
            }
        };

            mockDal.Setup(d => d.GetCustomer("abc", "abc", new DateOnly(2002, 10, 09))).Returns(customers);
            var controller = new FindCustomerController(mockDal.Object);

            // Act
            var result = controller.GetCustomer("abc", "abc", new DateOnly(2002, 10, 09));

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(customers, okResult.Value);
        }


        [Fact]
        public void GetCustomer_ReturnsNotFoundResult_WhenNoCustomersExist()
        {
            // Arrange
            var mockDal = new Mock<ICustomerDataAccess>();
            mockDal.Setup(d => d.GetCustomer("Peter", "Peter", new DateOnly(1990, 01, 02))).Returns((List<Customer>)null);
            var controller = new FindCustomerController(mockDal.Object);

            // Act
            var result = controller.GetCustomer("Peter", "Peter", new DateOnly(1990, 01, 02));

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void GetCustomer_ReturnsBadRequestResult_WhenExceptionIsThrown()
        {
            // Arrange
            var mockDal = new Mock<ICustomerDataAccess>();
            mockDal.Setup(d => d.GetCustomer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateOnly>())).Throws(new Exception("Database error"));
            var controller = new FindCustomerController(mockDal.Object);

            // Act
            var result = controller.GetCustomer("Peter", "Peter", new DateOnly(1990, 01, 02));

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Database error", badRequestResult.Value);
        }
    }
}
