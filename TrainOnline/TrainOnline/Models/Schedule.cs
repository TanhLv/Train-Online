using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainOnline.Models
{
    public class Schedule : Base
    {
        [Key]
        public int ScheduleId { get; set; }
        public string ScheduleName { get; set; } = "";

    }
}
