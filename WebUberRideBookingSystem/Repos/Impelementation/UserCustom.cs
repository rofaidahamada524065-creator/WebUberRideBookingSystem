using Microsoft.EntityFrameworkCore;
using WebUberRideBookingSystem.Data;
using WebUberRideBookingSystem.Model;
using WebUberRideBookingSystem.Repos.Interface;

namespace WebUberRideBookingSystem.Repos.Impelementation
{
    public class UserCustom : GenaricRepo<User>, IUserCustom
    {
        private readonly AppDbcontext _dbcontext;
        public UserCustom(AppDbcontext appDbcontext) : base(appDbcontext)
        {
            _dbcontext = appDbcontext;
        }

        public async Task<User> SearchByEmail(string email)
        {
            return await _dbcontext.Users.SingleOrDefaultAsync(a => a.Email == email);
        }
    }
}
