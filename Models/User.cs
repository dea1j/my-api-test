using System.ComponentModel.DataAnnotations;

namespace MAUIapi.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }

}
