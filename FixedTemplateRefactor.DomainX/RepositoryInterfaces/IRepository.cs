namespace FixedTemplateRefactor.DomainX.RepositoryInterfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        T GetById(int id);

        void SaveChanges();

        System.Collections.Generic.IEnumerable<T> All();
    }
}