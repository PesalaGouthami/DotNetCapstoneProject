using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanOrigination.Models.LoanHistory
{
    [Table("transactions")]
    public class TransactionsModel
    {
        [Key]
        [Column("transaction_id")]
        public int TransactionId { get; set; }

        [Column("loan_id")]
        public int LoanId { get; set; }

        [Column("amount_paid")]
        public decimal AmountPaid { get; set; }

        [Column("date_of_transcation")]
        public DateTime DateOfTransaction { get; set; }
    }
}

