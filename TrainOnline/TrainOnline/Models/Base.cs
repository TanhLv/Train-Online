using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainOnline.Models
{
    public class Base
    {
        public string? CreatedBy { get; set; } = "Admin";
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
