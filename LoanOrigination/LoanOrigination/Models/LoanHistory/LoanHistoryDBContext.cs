using Microsoft.EntityFrameworkCore;

namespace LoanOrigination.Models.LoanHistory
{
    public class LoanHistoryDBContext : DbContext
    {
        public LoanHistoryDBContext(DbContextOptions<LoanHistoryDBContext> options) : base(options) { }

        public DbSet<LoanHistoryModel> LoanHistory { get; set; }

        public DbSet<LoanApplication> LoanApplication { get; set; }


        public DbSet<TransactionsModel> Transactions { get; set; }



    }
}
