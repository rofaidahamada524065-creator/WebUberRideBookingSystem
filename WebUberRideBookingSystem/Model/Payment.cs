using System.ComponentModel.DataAnnotations;

namespace WebUberRideBookingSystem.Model
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        public string Status { get; set; }

        public int RiderId { get; set; }

        public int RideId { get; set; }

        public Ride Ride    { get; set; }



    }
}
