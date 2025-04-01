namespace LoanOrigination.Models
{
    public interface ILoanApplicationDataAccess
    {
       public decimal? GetNetIncomeByCustomerId(int customerId); // Synchronous method to get net income
       public void AddLoanApplication(LoanApplication loanApplication); // Synchronous method to add a loan application
    }
}
