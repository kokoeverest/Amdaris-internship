namespace Collections
{
    public class ListRepository<T> : IRepository<T> where T : Entity
    {
        private readonly List<T> _storage = [];
        public T? GetById(int Id)
        {
            foreach (var item in _storage)
                if (item.Id == Id) 
                    return item;
            return null;
        }
        public IList<T> GetAll()
        {
            return _storage;
        }
        public void Add(T entity)
        {
            _storage.Add(entity);
        }
        public void Delete(T entity)
        {
            _storage.Remove(entity);
        }
        public void Update(T entity)
        {
            for (int i = 0; i < _storage.Count; i++)
            {
                if (_storage[i].Id == entity.Id)
                {
                    _storage[i] = entity;
                }
            }
        }
        public bool Contains(T entity)
        {
            return _storage.Contains(entity);
        }
    }
}
