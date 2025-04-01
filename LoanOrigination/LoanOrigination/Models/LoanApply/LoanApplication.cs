using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanOrigination.Models
{
    [Table("loanapplication")]
    public class LoanApplication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("loan_id")]
        public int LoanId {  get; set; }
        [Column("customer_id")]
        public int CustomerId { get; set; }
        [Column("employee_id")]
        public int EmployeeId {  get; set; }
        [Column("loan_amount")]
        public double LoanAmount { get; set; }
        [Column("loan_status")]
        public string LoanStatus { get; set; } = "";
        [Column("date_of_request")]
        public DateOnly DateOfRequest {  get; set; }
        [Column("loan_tenure")]
        public int LoanTenure {  get; set; }
        [Column("rate_of_intrest")]
        public int RateOfIntrest { get; set; }
    }
}
