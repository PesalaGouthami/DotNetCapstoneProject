using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanOrigination.Models.LoanHistory
{
    [Table("loanhistory")]

    public class LoanHistoryModel
    {
        [Key]
        [Column("loan_id")]
        public int LoanId { get; set; }

        [Column("status")]
        public string Status { get; set; }


        [Column("loan_amount")]
        public decimal LoanAmount { get; set; }


        [Column("amount_paid")]
        public decimal AmountPaid { get; set; }


        [Column("remaining_balance")]
        public decimal RemainingBalance { get; set; }


        [Column("due_date")]
        public DateTime? DueDate { get; set; }
    }
}
