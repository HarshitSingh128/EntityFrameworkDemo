using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkDemo.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key] //this is primary key in the table
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }//? to allow null from db
        [Required]
        public string? City { get; set; }
        [Required]
        public Decimal Salary { get; set; }
    }
}
