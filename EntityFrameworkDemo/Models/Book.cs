using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EntityFrameworkDemo.Models
{
    [Table("Book")]
    public class Book
    {

        [Key] //this is primary key in the table
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }//? to allow null from db
       [Required]
        public Decimal Price { get; set; }

        [Required]
        public string Aname { get; set; }
    }
}
