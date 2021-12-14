using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
        public string Role { get; set; }
    }
}
