using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EntityFrameworkDemo.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int Sid{ get; set; }

        [Required]
        public string? Sname { get; set; }
        [Required]
        public int Sage { get; set; }
        [Required]
        public string? Semail { get; set; }
    }
}
