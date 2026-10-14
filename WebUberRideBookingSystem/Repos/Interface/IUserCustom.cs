using WebUberRideBookingSystem.Model;

namespace WebUberRideBookingSystem.Repos.Interface
{
    public interface IUserCustom:IGenaricRepo<User>
    {
        Task<User> SearchByEmail(string email);
    }
}
