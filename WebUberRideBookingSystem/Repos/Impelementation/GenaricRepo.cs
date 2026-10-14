using Microsoft.EntityFrameworkCore;
using WebUberRideBookingSystem.Data;
using WebUberRideBookingSystem.Repos.Interface;

namespace WebUberRideBookingSystem.Repos.Impelementation
{
    public class GenaricRepo<T> : IGenaricRepo<T> where T : class
    {
        private readonly AppDbcontext _context;
        public DbSet<T> db;
        public GenaricRepo(AppDbcontext appDbcontext)
        {
            _context = appDbcontext;
            db=_context.Set<T>();
            
        }

        public async Task Create(T entety)
        {
           await db.AddAsync(entety);
        }

        public async void Delete(int id)
        {
            var x=await db.FindAsync(id);
            if (x != null)
            {
                db.Remove(x);
            }
        }

        public async Task<ICollection<T>> GetAll()
        {
          return await db.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await db.FindAsync(id);
        }

        public void Update(T entety)
        {
            db.Update(entety);
        }
    }
}
