using Microsoft.EntityFrameworkCore;

namespace LoanOrigination.Models.Account
{
    public class UserDB : DbContext
    {
        public UserDB(DbContextOptions<UserDB> options) : base(options)
        {

        }

        public DbSet<Users> User { get; set; }
    }
}
