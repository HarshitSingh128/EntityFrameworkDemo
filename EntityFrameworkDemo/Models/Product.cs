using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EntityFrameworkDemo.Models
{
    [Table("Product")]
    public class Product
    {
        [Key] //this is primary key in the table
        public int Pid { get; set; }
        [Required]
        public string? Pname { get; set; }//? to allow null from db
      
        [Required]
        public Decimal Pprice { get; set; }
    }
}
