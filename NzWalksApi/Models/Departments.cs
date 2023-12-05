using System.ComponentModel.DataAnnotations;

namespace NzWalksApi.Models
{
    public class Departments
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        public string DeptWork { get; set; }

        // Other attributes can be added here
    }
}
