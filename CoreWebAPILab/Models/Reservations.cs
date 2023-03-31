using System.ComponentModel.DataAnnotations;

namespace CoreWebAPILab.Models
{
    public class Reservations
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string StartLocation { get; set; }
        [Required]
        public string EndLocation { get; set; }
    }
}