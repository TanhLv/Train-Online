using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainOnline.Models
{
    public class TrainTrip : Base
    {
        [Key]
        public int TrainTripId { get; set; }
        public string TrainTripCode { get; set; } = "";
        public int? TrainId { get; set; } = null;
        public int? ScheduleId { get; set; } = null;
        public DateTime DepartureTime { get; set; } = DateTime.Now;
        public DateTime ArrivalTime { get; set; } = DateTime.Now;

        [ForeignKey("TrainId")]
        public virtual Train GetTrainId { get; set; } = null;

        [ForeignKey("ScheduleId")]
        public virtual Schedule GetScheduleId { get; set; } = null;

    }
}
