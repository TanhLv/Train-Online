using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainOnline.Models
{
    public class Seat : Base
    {
        [Key]
        public int SeatId { get; set; }
        public string SeatCode { get; set; } = "";
        public int? TrainCarId { get; set; } = null;
        public int? TypeId { get; set; } = null;
        public int? StatusId { get; set; } = null;

        [ForeignKey("TrainCarId")]
        public virtual TrainCar GetTrainCarId { get; set; } = null;

        [ForeignKey("TypeId")]
        public virtual _Type GetTypeId { get; set; } = null;

        [ForeignKey("StatusId")]
        public virtual _Status GetStatusId { get; set; } = null;
    }
}
