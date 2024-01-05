namespace TrainOnline.DTO
{
	public class HienThiVeDatDTO
	{
        public int TicketId { get; set; }
        public string TicketCode { get; set; }
        public string Name { get; set; }
		public int TotalTicketPrice { get; set; }
		public int TrainTripId { get; set; }
		public string DepartureStation { get; set; }
		public string ArrivalStation { get; set; }
		public DateTime GioDi { get; set; }
		public DateTime GioDen { get; set; }
	}
}
