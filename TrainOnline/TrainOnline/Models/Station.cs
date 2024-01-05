using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainOnline.Models
{
    public class Station : Base
    {
        [Key]
        public int StationId { get; set; }
        public string StationName { get; set; } = "";
    }
}
