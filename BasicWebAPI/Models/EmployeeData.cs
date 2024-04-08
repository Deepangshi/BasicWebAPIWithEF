using System.ComponentModel.DataAnnotations;

namespace BasicWebAPI.Models
{
    public class EmployeeData
    {
        [Key]
        public int EmployeeDataId { get; set; }
        [Required]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Position { get; set; }
        [MaxLength(50)]
        public string Company { get; set; }


    }
}
