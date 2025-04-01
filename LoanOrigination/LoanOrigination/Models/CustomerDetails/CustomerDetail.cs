using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanOrigination.CustomerDetails.Models
{
    [Table("customer")]
    public class CustomerDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("firstname")]
        [Required]
        public string FirstName { get; set; }

        [Column("lastname")]
        [Required]
        public string LastName { get; set; }

        [Column("date_of_birth")]
        [Required]
        public DateOnly Date_of_Birth { get; set; }

        [Column("phone")]
        [Required]
        [StringLength(10)]
        public string Phone { get; set; }

        [Column("email")]
        [Required]
        public string Email { get; set; }

        [Column("address")]
        [Required]
        public string Address { get; set; }

        [Column("company_name")]
        [Required]
        public string Company_Name { get; set; }

        [Column("salary")]
        [Required]
        public decimal Salary { get; set; }

        [Column("net_income")]
        [Required]
        public decimal Net_Income { get; set; }

        [Column("last_salary_date")]
        [Required]
        public DateOnly Last_salary_date { get; set; }

    }
}
