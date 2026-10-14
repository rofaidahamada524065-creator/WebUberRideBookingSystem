using System.ComponentModel.DataAnnotations;

namespace WebUberRideBookingSystem.Model
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string PlateNumber { get; set; }
        [Required]

        public string color { get; set; }
       

    

        [Required]
        public int DriverId { get; set; }
        public User Drive { get; set; }

       
    }
}
