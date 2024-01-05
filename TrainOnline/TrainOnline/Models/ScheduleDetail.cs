using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainOnline.Models
{
    public class ScheduleDetail : Base
    {
        [Key]
        public int ScheduleDetailId { get; set; }
        public int? ScheduleId { get; set; } = null;
        public int? CurrentStation { get; set; } = null;
        public int? NextStation { get; set; } = null;
        public decimal? PriceToTheNextStation { get; set; } = 0;

        [ForeignKey("ScheduleId")]
        public virtual Schedule GetScheduleId { get; set; }

        [ForeignKey("CurrentStation")]
        public virtual Station GetCurrentStation { get; set; }

        [ForeignKey("NextStation")]
        public virtual Station GetNextStation { get; set; }
    }
}
