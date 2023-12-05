using System.ComponentModel.DataAnnotations;

namespace NzWalksApi.Models
{
    public class Roles
    {
        [Key]
        public int RoleID { get; set; } 

        [Required]
        public string RoleName { get; set; }

        public string? Responsibilities { get; set; } = "None";

        // Other attributes can be added here
    }
}
