namespace ClubManagmentSystem.Repos.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        void Add(T item);
        void Delete(T item);
        void Update(T item);

    }
}
