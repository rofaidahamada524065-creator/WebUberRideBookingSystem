using System.ComponentModel.DataAnnotations;

namespace WebUberRideBookingSystem.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100,MinimumLength =3)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        [Phone]
        public string phonenumber { get; set; }
     
        public int RiderId { get; set; }

      
        public int DriverId { get; set; }

        public  Vehicle Vehicle { get; set; }


        public ICollection<Ride> DriverRide {  get; set; }=new List<Ride>();
        public ICollection<Ride> RideRider {  get; set; }=new List<Ride>();

    }
}
