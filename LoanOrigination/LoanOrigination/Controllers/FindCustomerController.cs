using LoanOrigination.Models.CustomerSearch;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanOrigination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindCustomerController : ControllerBase
    {

        private readonly ICustomerDataAccess dal;
        public FindCustomerController(ICustomerDataAccess dal)
        {
            this.dal = dal;
        }

        [HttpGet]
        [Route("customers/search/{firstName}/{lastName}/{dateOfBirth}")]
        public IActionResult GetCustomer(string firstName, string lastName, DateOnly dateOfBirth)
        {
            try
            {
                var res = dal.GetCustomer(firstName, lastName, dateOfBirth);
                if (res == null)
                {
                    return NotFound("Customer not found");
                }
                else
                {
                    return Ok(res);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
