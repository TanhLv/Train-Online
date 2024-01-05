using System.ComponentModel.DataAnnotations;

namespace TrainOnline.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string Name { get; set; } = "";
        public int? Age { get; set; } = null;
        public string Gender { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string Address { get; set; } = "";
    }
}
