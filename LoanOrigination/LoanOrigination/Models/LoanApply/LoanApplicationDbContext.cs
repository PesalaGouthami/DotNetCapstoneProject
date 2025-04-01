using LoanOrigination.Models.Account;
using LoanOrigination.Models.CustomerSearch;
using Microsoft.EntityFrameworkCore;

namespace LoanOrigination.Models
{
    public class LoanApplicationDbContext:DbContext
    {
        public LoanApplicationDbContext(DbContextOptions<LoanApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<LoanApplication> LoanApplication { get; set; }
        public DbSet<Customer> Customers { get; set; }
        //public DbSet<EmploymentDetails> EmploymentDetails { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
