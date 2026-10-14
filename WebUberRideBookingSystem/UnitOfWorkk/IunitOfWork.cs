using WebUberRideBookingSystem.Repos.Interface;

namespace WebUberRideBookingSystem.UnitOfWorkk
{
    public interface IunitOfWork
    {
        IUserCustom userCustom { get; }

        Task<int> SaveChangesAsync();
    }
}
