using Moq;
using Microsoft.AspNetCore.Mvc;
using LoanOrigination.Models;
using LoanOrigination.Controllers;
using Xunit;

public class LoanApplicationControllerTests
{
    private readonly Mock<ILoanApplicationDataAccess> mockDataAccess;
    private readonly LoanApplicationController controller;

    public LoanApplicationControllerTests()
    {
        mockDataAccess = new Mock<ILoanApplicationDataAccess>();
        controller = new LoanApplicationController(mockDataAccess.Object);
    }

    [Fact]
    public void CalculateAndAddLoan_ValidRequest_ReturnsOk()
    {
        // Arrange
        int customerId = 1;
        var loanRequest = new LoanApplication { LoanId = 100, LoanAmount = 5000 };

        mockDataAccess.Setup(m => m.GetNetIncomeByCustomerId(customerId)).Returns(15000);
        mockDataAccess.Setup(m => m.AddLoanApplication(loanRequest));

        // Act
        var result = controller.CalculateAndAddLoan(customerId, loanRequest) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.Contains("Loan application added successfully.", result.Value.ToString());
    }

    [Fact]
    public void CalculateAndAddLoan_InvalidCustomerId_ReturnsBadRequest()
    {
        // Arrange
        int customerId = -1;
        var loanRequest = new LoanApplication { LoanId = 100, LoanAmount = 5000 };

        // Act
        var result = controller.CalculateAndAddLoan(customerId, loanRequest) as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("Invalid Customer ID",
            result.Value.GetType().GetProperty("error")?.GetValue(result.Value));
    }

    [Fact]
    public void CalculateAndAddLoan_CustomerNotFound_ReturnsNotFound()
    {
        // Arrange
        int customerId = 999;
        var loanRequest = new LoanApplication { LoanId = 100, LoanAmount = 5000 };

        mockDataAccess.Setup(m => m.GetNetIncomeByCustomerId(customerId)).Returns((decimal?)null);

        // Act
        var result = controller.CalculateAndAddLoan(customerId, loanRequest) as NotFoundObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(404, result.StatusCode);
        Assert.Equal("Customer not found or does not have Employment Details.",
            result.Value.GetType().GetProperty("error")?.GetValue(result.Value));
    }

    [Fact]
    public void CalculateAndAddLoan_InvalidLoanAmount_ReturnsBadRequest()
    {
        // Arrange
        int customerId = 1;
        var loanRequest = new LoanApplication { LoanId = 100, LoanAmount = 2000 }; // Below suggestedLoanAmount
        decimal netIncome = 9000;

        mockDataAccess.Setup(m => m.GetNetIncomeByCustomerId(customerId)).Returns(netIncome);

        // Act
        var result = controller.CalculateAndAddLoan(customerId, loanRequest) as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(400, result.StatusCode);
        Assert.Contains("Loan amount should be greater than the suggested amount and less than the maximum amount.",
            result.Value.ToString());
    }

    [Fact]
    public void GetNetIncomeByCustomerId_ValidCustomerId_ReturnsOk()
    {
        // Arrange
        int customerId = 1;
        decimal netIncome = 12000;

        mockDataAccess.Setup(m => m.GetNetIncomeByCustomerId(customerId)).Returns(netIncome);

        // Act
        var result = controller.GetNetIncomeByCustomerId(customerId) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(netIncome, result.Value);
    }

    [Fact]
    public void GetNetIncomeByCustomerId_InvalidCustomerId_ReturnsBadRequest()
    {
        // Arrange
        int customerId = -1;

        // Act
        var result = controller.GetNetIncomeByCustomerId(customerId) as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("Invalid Customer ID",
            result.Value.GetType().GetProperty("error")?.GetValue(result.Value));
    }
}
