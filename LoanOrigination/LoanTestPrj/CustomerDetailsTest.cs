using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanAppExceptionLib;
using LoanOrigination.Controllers;
using LoanOrigination.CustomerDetails.Models;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Utilities;
using Moq;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using LoanOrigination.Models.CustomerSearch;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LoanTestPrj
{
    public class CustomerDetailsTest
    {

        private readonly Mock<ICustomerDetailsDataAccess> _mockDataAccess; 
        private readonly AddCustomerController _controller;              

        public CustomerDetailsTest()
        {
            _mockDataAccess = new Mock<ICustomerDetailsDataAccess>();
            _controller = new AddCustomerController(_mockDataAccess.Object);
        }
       

        [Fact]
        public void AddCustomerDetails_ShouldReturnOk_WhenDetailsAreValid()
        {
            // Arrange
            var customerDetails = new CustomerDetail
            {
                FirstName = "John",
                LastName = "Doe",
                Date_of_Birth = new DateOnly(1990, 1, 1),
                Phone = "1234567890",
                Email = "john.doe@example.com",
                Address = "123 Main Street",
                Company_Name = "Tech Corp",
                Salary = 50000,
                Net_Income = 40000,
                Last_salary_date = new DateOnly(2023, 12, 31)
            };

            _mockDataAccess.Setup(dal => dal.AddCustomerDetails(It.IsAny<CustomerDetail>()));

        
            var result = _controller.AddCustomerDetails(customerDetails);

          
            var okResult = Assert.IsType<OkObjectResult>(result);
            var objValue = okResult.Value;
            var msg =objValue.GetType().GetProperty("msg")?.GetValue(objValue, null);
            Assert.Equal("CustomerDetails added Successfully", msg);

           
            //_mockDataAccess.Verify(dal => dal.AddCustomerDetails(It.IsAny<CustomerDetail>()), Moq.Times.Once);
        }

        [Fact]
        public void AddCustomerDetails_ShouldReturnBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var customerDetails = new CustomerDetail
            {
                FirstName = "Jane",
                LastName = "Smith",
                Date_of_Birth = new DateOnly(1995, 1, 1),
                Phone = "0987654321",
                Email = "jane.smith@example.com",
                Address = "456 Elm Street",
                Company_Name = "Innovate Inc",
                Salary = 60000,
                Net_Income = 50000,
                Last_salary_date = new DateOnly(2023, 11, 30)
            };

            _mockDataAccess.Setup(dal => dal.AddCustomerDetails(It.IsAny<CustomerDetail>()))
                .Throws(new Exception("An error occurred while adding customer details."));

        
            var result = _controller.AddCustomerDetails(customerDetails);

         
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var objValue = badRequestResult.Value;
            var msg=objValue.GetType().GetProperty("msg")?.GetValue(objValue, null);
            Assert.Equal("An error occurred while adding customer details.", msg);
            //Assert.Equal("An error occurred while adding customer details.", ((dynamic)badRequestResult.Value).msg);


            //_mockDataAccess.Verify(dal => dal.AddCustomerDetails(It.IsAny<CustomerDetail>()), Moq.Times.Once);
        }
    }
}