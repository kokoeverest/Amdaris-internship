namespace Collections
{
    public interface IRepository<T> where T : Entity
    {
        T? GetById(int Id);
        IList<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
