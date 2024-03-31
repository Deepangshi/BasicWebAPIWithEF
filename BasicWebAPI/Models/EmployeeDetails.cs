using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BasicWebAPI.Models
{
    public class EmployeeDetails
    {
        [Key]
        public int EmployeeDetailsID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string Name { get; set; } = "";

        public string Email { get; set; }

        public int ContactNumber { get; set; }

        public string Address { get; set; }

        public int Age { get; set; }
    }
}
