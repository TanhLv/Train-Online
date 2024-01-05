using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainOnline.Models
{
    public class Ticket : Base
    {
        [Key]
        public int TicketId { get; set; }
        public string TicketCode { get; set; } = "";
        public int? PassengerInformation { get; set; } = null;
        public int? TotalTicketPrice { get; set; } = null;
        public int? TrainTripId { get; set; } = null;
        public int? SeatId { get; set; } = null;
        public int? DepartureStation { get; set; } = null;
        public int? ArrivalStation { get; set; } = null;

        [ForeignKey("PassengerInformation")]
        public virtual Passenger GetPassengerInformation { get; set; } = null;

        //[ForeignKey("TrainTripId")]
        //public virtual TrainTrip GetTrainTripId { get; set; } = null;

        [ForeignKey("SeatId")]
        public virtual Seat GetSeatId { get; set; } = null;

        [ForeignKey("DepartureStation")]
        public virtual Station GetDepartureStation { get; set; } = null;

        [ForeignKey("ArrivalStation")]
        public virtual Station GetArrivalStation { get; set; } = null;
    }
}
