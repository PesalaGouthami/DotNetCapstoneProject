using Microsoft.EntityFrameworkCore;

namespace LoanOrigination.CustomerDetails.Models
{
    public class CustomerDetailsDBContext :DbContext
    {
        public CustomerDetailsDBContext(DbContextOptions opts) : base(opts) 
        {
            
        }
        public DbSet<CustomerDetail>CustomerDetails {  get; set; }
    }
}
