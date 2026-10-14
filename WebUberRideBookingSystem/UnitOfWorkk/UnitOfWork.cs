using WebUberRideBookingSystem.Data;
using WebUberRideBookingSystem.Repos.Interface;

namespace WebUberRideBookingSystem.UnitOfWorkk
{
    public class UnitOfWork : IunitOfWork
    {
        private readonly AppDbcontext _dbcontext;
        public UnitOfWork(AppDbcontext appDbcontext,IUserCustom userCustom)
        {
            _dbcontext = appDbcontext;
            this.userCustom = userCustom;   
        }
        public IUserCustom userCustom { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbcontext.SaveChangesAsync();
        }
    }
}
