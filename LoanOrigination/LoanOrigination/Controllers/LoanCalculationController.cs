using LoanOrigination.Exceptions;
using LoanOrigination.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LoanOrigination.Controllers
{
    [ApiController]
    [Route("api/loan")]
    public class LoanApplicationController : ControllerBase
    {
        private readonly ILoanApplicationDataAccess _dataAccess;

        public LoanApplicationController(ILoanApplicationDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        [HttpPost]
        [Route("calculate-and-add/{customerId}")]
        public IActionResult CalculateAndAddLoan(int customerId, [FromBody] LoanApplication loanRequest)
        {
            if (customerId <= 0 )
            {
                return BadRequest(new { error = "Invalid Customer ID" });
            }

            // Step 1: Fetch Net Income
            var netIncome = _dataAccess.GetNetIncomeByCustomerId(customerId);
            if (netIncome == null)
            {
                return NotFound(new { error = "Customer not found or does not have Employment Details." });
            }

            // Step 2: Calculate Suggested and Maximum Loan Amount
            int suggestedLoanAmount = (int)Math.Round((decimal)netIncome / 3, MidpointRounding.AwayFromZero);
            int maximumLoanAmount = (int)Math.Round((decimal)netIncome / 2, MidpointRounding.AwayFromZero);

            // Validate Loan Amount
            if (loanRequest.LoanAmount< suggestedLoanAmount || loanRequest.LoanAmount > maximumLoanAmount)
            {
                return BadRequest(new
                {
                    error = "Loan amount should be greater than the suggested amount and less than the maximum amount.",
                    suggestedLoanAmount,
                    maximumLoanAmount
                });
            }

            
            // Step 3: Add Loan Application
            try
            {
                _dataAccess.AddLoanApplication(loanRequest); 
                return Ok(new
                {
                    message = "Loan application added successfully.",
                    loanRequest.LoanId,
                    suggestedLoanAmount,
                    maximumLoanAmount
                });
            }
            catch (LoanApplicationException ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetNetIncomeByCustomerId([FromQuery] int customerId)
        {
            if(customerId <= 0)
            {
                return BadRequest(new { error = "Invalid Customer ID" });
            }
            var netIncome = _dataAccess.GetNetIncomeByCustomerId(customerId);
            return Ok(netIncome);
        }
    }
}
