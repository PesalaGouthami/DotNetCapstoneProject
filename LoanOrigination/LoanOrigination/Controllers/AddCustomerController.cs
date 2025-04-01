
using LoanOrigination.CustomerDetails.Models;
using LoanOrigination.Models.CustomerSearch;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanOrigination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddCustomerController : ControllerBase
    {
        private readonly ICustomerDetailsDataAccess dal;
        public AddCustomerController(ICustomerDetailsDataAccess dal) 
        {
            this.dal = dal;
        }
        [HttpPost]
        [Route("AddCustomerDetails")]
        public IActionResult AddCustomerDetails([FromBody] CustomerDetail customerDetails)
        {
            try
            {
                dal.AddCustomerDetails(customerDetails);
                return Ok(new { msg = "CustomerDetails added Successfully" });

            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = ex.Message });
            }

        }
    }
}
