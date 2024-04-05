using System.ComponentModel.DataAnnotations;

namespace Libraby.Models
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
    }
}
