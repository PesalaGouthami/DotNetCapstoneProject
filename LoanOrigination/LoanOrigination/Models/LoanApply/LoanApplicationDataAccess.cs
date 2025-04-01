using Microsoft.EntityFrameworkCore;

namespace LoanOrigination.Models
{
    public class LoanApplicationDataAccess : ILoanApplicationDataAccess
    {
        private readonly LoanApplicationDbContext _dbContext;

        public LoanApplicationDataAccess(LoanApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public decimal? GetNetIncomeByCustomerId(int customerId)
        {
            var employment = _dbContext.Customers.FirstOrDefault(e => e.Id == customerId);
            return employment?.Net_Income;
        }

        public void AddLoanApplication(LoanApplication loanApplication)
        {
            _dbContext.LoanApplication.Add(loanApplication);
            _dbContext.SaveChanges();
        }
    }
}
