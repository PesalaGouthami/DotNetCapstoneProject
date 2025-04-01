using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanAppExceptionLib;
using LoanOrigination.Controllers;
using LoanOrigination.Models.LoanHistory;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LoanTestPrj
{
    public class LoanHistoryTest
    {
        private readonly Mock<ILoanHistoryDAO> dal;
        private readonly LoanHistoryController cal;

        public LoanHistoryTest()
        {
            dal = new Mock<ILoanHistoryDAO>();
            cal = new LoanHistoryController(dal.Object);
        }

        [Fact]
        public void GetLoanHistoryByCustomerId_ValidCustomerId_ReturnsLoanHistory()
        {
           
            int customerId = 1;
            var loanHistory = new List<LoanHistoryModel>
        {
            new LoanHistoryModel { LoanId = 1, Status = "Active", LoanAmount = 10000, AmountPaid = 2000, RemainingBalance = 8000, DueDate = System.DateTime.Now.AddDays(30) }
        };
            dal.Setup(d => d.GetLoanHistoryByCustomerId(customerId)).Returns(loanHistory);

            var result = cal.GetLoanHistoryByCustomerId(customerId) as OkObjectResult;

           
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            var data=result.Value.GetType().GetProperty("data").GetValue(result.Value);

            Assert.Equal(loanHistory, data);
        }

        [Fact]
        public void GetLoanHistoryByCustomerId_InvalidCustomerId_ReturnsBadRequest()
        {
           
            var result = cal.GetLoanHistoryByCustomerId(-1) as BadRequestObjectResult;

            
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Invalid Customer ID", result.Value.GetType().GetProperty("message")?.GetValue(result.Value));
        }

        [Fact]
        public void GetLoanHistoryByCustomerId_CustomerNotFound_ThrowsException()
        {
            
            int customerId = 999;
              dal.Setup(d => d.GetLoanHistoryByCustomerId(customerId))
                    .Throws(new CustomerNotFoundException("No loan history found for the provided Customer ID."));

            
            var result = cal.GetLoanHistoryByCustomerId(customerId) as NotFoundObjectResult;

      
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("No loan history found for the provided Customer ID.", result.Value.GetType().GetProperty("message")?.GetValue(result.Value));
        }

        [Fact]
        public void GetTransactionsByLoanId_ValidLoanId_ReturnsTransactions()
        {
           
            int loanId = 1;
            var transactions = new List<TransactionsModel>
        {
            new TransactionsModel { TransactionId = 1, LoanId = 1, AmountPaid = 500, DateOfTransaction = System.DateTime.Now }
        };
            dal.Setup(d => d.GetTransactionsByCustomerId(loanId)).Returns(transactions);

           
            var result = cal.GetTransactionsByLoanId(loanId) as OkObjectResult;

            
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            var data = result.Value.GetType().GetProperty("data").GetValue(result.Value);

            Assert.Equal(transactions, data);
        }

        [Fact]
        public void GetTransactionsByLoanId_InvalidLoanId_ReturnsBadRequest()
        {
           
            var result = cal.GetTransactionsByLoanId(-1) as BadRequestObjectResult;

          
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Invalid Loan ID", result.Value.GetType().GetProperty("message")?.GetValue(result.Value));
        }

        [Fact]
        public void GetTransactionsByLoanId_NoTransactionsFound_ThrowsException()
        {
           
            int loanId = 999;
            dal.Setup(d => d.GetTransactionsByCustomerId(loanId))
                    .Throws(new CustomerNotFoundException("No transactions found for the provided Loan ID."));

       
            var result =cal.GetTransactionsByLoanId(loanId) as NotFoundObjectResult;

       
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("No transactions found for the provided Loan ID.", result.Value.GetType().GetProperty("message")?.GetValue(result.Value));
        }
    }
}
