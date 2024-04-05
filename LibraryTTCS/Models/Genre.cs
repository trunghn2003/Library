using System.ComponentModel.DataAnnotations;

namespace Libraby.Models
{
    public class Genre
    {
        [Key]
        public int GenreID { get; set; }
        public string GenreName { get; set; }
    }
}
