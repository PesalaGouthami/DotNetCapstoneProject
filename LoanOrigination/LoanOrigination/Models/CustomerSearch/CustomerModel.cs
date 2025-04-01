using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanOrigination.Models.CustomerSearch
{
    [Table("Customer")]
    public class CustomerModel
    {
        [Key]
        [Column("id")]
        public int Customer_Id { get; set; }

        [Column("fistname")]
        public string Firstname { get; set; }
        [Column("lastname")]
        public string Lastname { get; set; }

        [Column("dateofbirth")]
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
