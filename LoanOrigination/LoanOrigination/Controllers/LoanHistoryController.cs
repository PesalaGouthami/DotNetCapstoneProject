using LoanAppExceptionLib;
using LoanOrigination.Models.LoanHistory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LoanOrigination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanHistoryController : ControllerBase
    {
        private readonly ILoanHistoryDAO dal;

        public LoanHistoryController(ILoanHistoryDAO dal)
        {
            this.dal = dal;
        }

        [HttpGet]
        [Route("GetLoanHistoryByCustomerId/{customerId}")]
        public IActionResult GetLoanHistoryByCustomerId(int customerId)
        {
            try
            {
                if (customerId <= 0)
                {
                    return BadRequest(new { statusCode = 400, message = "Invalid Customer ID" });
                }

                List<LoanHistoryModel> loanHistory = dal.GetLoanHistoryByCustomerId(customerId);

                return Ok(new { statusCode = 200, data = loanHistory });
            }
            catch (CustomerNotFoundException ex)
            {
                return NotFound(new { statusCode = 404, message = ex.Message });
            }
            catch (DatabaseAccessException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { statusCode = 500, message = "Database access error occurred", details = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { statusCode = 500, message = "An unexpected error occurred", details = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetTransactionsByLoanId/{loanId}")]
        public IActionResult GetTransactionsByLoanId(int loanId)
        {
            try
            {
                if (loanId <= 0)
                {
                    return BadRequest(new { statusCode = 400, message = "Invalid Loan ID" });
                }

                List<TransactionsModel> transactions = dal.GetTransactionsByCustomerId(loanId);

                return Ok(new { statusCode = 200, data = transactions });
            }
            catch (CustomerNotFoundException ex)
            {
                return NotFound(new { statusCode = 404, message = ex.Message });
            }
            catch (DatabaseAccessException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { statusCode = 500, message = "Database access error occurred", details = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { statusCode = 500, message = "An unexpected error occurred", details = ex.Message });
            }
        }
    }
}
