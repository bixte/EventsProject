using EventsProject.Models.Data;

namespace EventsProject.Models.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        public IList<T> Entities { get; set; } = null!;
        public void Add(T entity)
        {
            Entities.Add(entity);
        }

        public T? Find(Guid id)
        {
            return Entities.FirstOrDefault(e => e.Id == id);
        }

        public void Remove(T entity)
        {
            Entities.Remove(entity);
        }

        public void Update(T entity)
        {
            var entityCache = Entities.FirstOrDefault(e => e.Id == entity.Id);
            if (entityCache == null)
                throw new Exception("not found");
            entityCache = entity;
        }
    }
}
