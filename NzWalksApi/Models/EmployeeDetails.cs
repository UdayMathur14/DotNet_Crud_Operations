using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NzWalksApi.Models
{
    public class EmployeeDetails
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [MinLength(3 , ErrorMessage ="Minimum length should be 3")]
        [MaxLength(10, ErrorMessage = "maximum length should be 10")]

        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [ForeignKey("DepId")]
        public int DepartmentID { get; set; }

        public Departments DepId { get; set; }
        [Required]
        public Roles RoleId { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }

        [Required]
        public decimal Salary { get; set; }
    }
}
