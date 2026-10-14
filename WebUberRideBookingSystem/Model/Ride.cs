using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Identity.Client.AppConfig;

namespace WebUberRideBookingSystem.Model
{
    public class Ride
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(150)]
        public string DropOffLocation { get; set; }
        [Required,MaxLength(150)]
        public string PickupLocation { get; set; }
        [Range(20,5000)]
        public int Fare {  get; set; }
        [Required]
        public string Status {  get; set; }

        public int RiderId { get; set; }
        

        public int DriverId { get; set; }

        public User? Rider {  get; set; }
        public User? Driver { get; set; }

        public Payment Payment { get; set; }

        public Rating Rating { get; set; }


      
    }
}
