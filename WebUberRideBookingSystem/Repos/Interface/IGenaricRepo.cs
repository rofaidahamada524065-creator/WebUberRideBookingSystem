namespace WebUberRideBookingSystem.Repos.Interface
{
    public interface IGenaricRepo< T> where T : class
    {
        void Delete(int id);
        void Update(T entety);
        Task<T> GetByIdAsync(int id);
        Task<ICollection<T>> GetAll();

        Task Create(T entety);
    }
}
