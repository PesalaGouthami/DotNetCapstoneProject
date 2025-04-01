namespace LoanOrigination.Models.LoanHistory
{
    public interface ILoanHistoryDAO
    {
        public List<LoanHistoryModel> GetLoanHistoryByCustomerId(int customerId);

        public List<TransactionsModel> GetTransactionsByCustomerId(int LoanId);
    }
}
