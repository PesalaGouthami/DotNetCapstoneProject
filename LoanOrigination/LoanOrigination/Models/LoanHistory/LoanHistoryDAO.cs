using System.Collections.Generic;
using LoanAppExceptionLib;
using Npgsql;

namespace LoanOrigination.Models.LoanHistory
{
    public class LoanHistoryDAO : ILoanHistoryDAO
    {
        private readonly LoanHistoryDBContext ctx;

        public LoanHistoryDAO(LoanHistoryDBContext ctx)
        {
            this.ctx = ctx;
        }

        public List<LoanHistoryModel> GetLoanHistoryByCustomerId(int customerId)
        {
            try
            {
                List<LoanHistoryModel> record = ctx.LoanHistory.Join(
                                                ctx.LoanApplication, lh => lh.LoanId, la => la.LoanId,
                                                (lh, la) => new { LoanHistory = lh, LoanApplication = la })
                                                .Where(result => result.LoanApplication.CustomerId == customerId)
                              .Select(result => new LoanHistoryModel
                              {
                                  LoanId = result.LoanHistory.LoanId,
                                  Status = result.LoanHistory.Status,
                                  LoanAmount = result.LoanHistory.LoanAmount,
                                  AmountPaid = result.LoanHistory.AmountPaid,
                                  RemainingBalance = result.LoanHistory.RemainingBalance,
                                  DueDate = result.LoanHistory.DueDate
                              }).ToList();

                if (record == null || record.Count == 0)
                {
                    throw new CustomerNotFoundException("No loan history found for the provided Customer ID.");
                }

                return record;
            }
            catch (NpgsqlException ex)
            {
                throw new DatabaseAccessException("A database error occurred while fetching loan history.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while fetching loan history.", ex);
            }
        }

        public List<TransactionsModel> GetTransactionsByCustomerId(int loanId)
        {
            try
            {
                List<TransactionsModel> record = ctx.Transactions
                    .Where(t => t.LoanId == loanId)
                    .Select(t => new TransactionsModel
                    {
                        TransactionId = t.TransactionId,
                        LoanId = t.LoanId,
                        AmountPaid = t.AmountPaid,
                        DateOfTransaction = t.DateOfTransaction
                    })
                    .ToList();

                if (record == null || record.Count == 0)
                {
                    throw new CustomerNotFoundException("No transactions found for the provided Loan ID.");
                }

                return record;
            }
            catch (NpgsqlException ex)
            {
                throw new DatabaseAccessException("A database error occurred while fetching transactions.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while fetching transactions.", ex);
            }
        }
    }
}
