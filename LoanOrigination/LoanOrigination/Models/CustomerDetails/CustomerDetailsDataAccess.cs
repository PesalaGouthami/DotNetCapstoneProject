using LoanAppExceptionLib;
using Npgsql;

namespace LoanOrigination.CustomerDetails.Models
{
    public class CustomerDetailsDataAccess : ICustomerDetailsDataAccess
    {
        private readonly CustomerDetailsDBContext _dbContext;
        public CustomerDetailsDataAccess(CustomerDetailsDBContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public void AddCustomerDetails(CustomerDetail customerDetails)
        {
            try
            {
                if (customerDetails == null)
                {
                    throw new CustomerException("Customer object cannot be null.");
                }
                _dbContext.Add(customerDetails);
                _dbContext.SaveChanges();
            }
            catch(NpgsqlException ex)
            {
                //log the exception ex
                throw new Exception("some database error,try later:"+ex.Message);
            }
            catch (Exception ex)
            {
                //log the exception ex 
                throw new CustomerException("An error occurred while adding the customerDetails.");
            }
           
        }
    }
}
