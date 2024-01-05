using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainOnline.Models
{
    public class Passenger : Base
    {
        [Key]
        public int PassengerId { get; set; }
        public string Name { get; set; } = "";
        public int? Age { get; set; } = null;
        public string Gender { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public int? Number { get; set; } = null;
    }
}
