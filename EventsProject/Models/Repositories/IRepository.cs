using EventsProject.Models.Data;

namespace EventsProject.Models.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        public void Add(T entity);
        public T? Find(Guid id);
        public void Update(T entity);
        public void Remove(T entity);
    }
}
