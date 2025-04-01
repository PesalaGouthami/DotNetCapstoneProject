using LoanAppExceptionLib;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace LoanOrigination.Models.CustomerSearch
{
    public class CustomerDataAccess : ICustomerDataAccess
    {
        private readonly CustomerDbContext dbContext;
        public CustomerDataAccess(CustomerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Customer> GetCustomer(string firstName, string lastName, DateOnly dateOfBirth)
        {
            try
            {
                var record = dbContext.Customers.Where(c => c.FirstName == firstName && c.LastName == lastName && c.Date_of_Birth == dateOfBirth).ToList();
                if (record != null)
                {
                    return record;
                }
                else
                {
                    throw new CustomerNotFoundException("Customer not found");
                }
            }
            catch (NpgsqlException ex)
            {
                throw new Exception("Error in DB" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }
    }
}
