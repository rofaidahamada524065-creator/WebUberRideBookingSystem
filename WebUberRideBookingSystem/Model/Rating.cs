using System.ComponentModel.DataAnnotations.Schema;

namespace WebUberRideBookingSystem.Model
{
    public class Rating
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }

        public int RideId { get; set; }
        [ForeignKey("RideId")]
        public Ride Rrde { get; set; }
    
}
}
