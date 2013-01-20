using FixedTemplateRefactor.DomainX.DBContext;
using FixedTemplateRefactor.DomainX.RepositoryInterfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FixedTemplateRefactor.DomainX.Repositories
{
    public abstract class DomainXRepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly IDbSet<T> dbset;
        private DomainXDBContext db;


        /// <summary>
        /// Holds a reference to the DatabaseFactory class used to manage connections to the database.
        /// </summary>
        protected IDomainXDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        /// <summary>
        /// Contains a reference to the <see cref="System.Data.Entity.DbContext"/> instance used by the repository.
        /// </summary>
        protected DomainXDBContext CustomerDb
        {
            get
            {
                return this.db ?? (this.db = this.DatabaseFactory.GetDBContext());
            }
        }

        public DomainXRepositoryBase(IDomainXDatabaseFactory dbFactory)
        {
            this.DatabaseFactory = dbFactory;
            this.dbset = this.CustomerDb.Set<T>();
        }

        /// <summary>
        /// Adds a new entity instance to the database on behalf of the parent type.
        /// </summary>
        public virtual void Add(T entity)
        {
            this.dbset.Add(entity);
        }

        /// <summary>
        /// Deletes an existing instance of an entity from the database on behalf of the parent type.
        /// </summary>
        public virtual void Delete(T entity)
        {
            this.dbset.Remove(entity);
        }

        /// <summary>
        /// Returns a specific instance of an entity from the database on behalf of the parent type.
        /// </summary>
        /// <param name="id">The integer value of the entity's primary key</param>
        public virtual T GetById(int id)
        {
            return this.dbset.Find(id);
        }

        /// <summary>
        /// Returns an IEnumerable collection of all objects found in the database of type T
        /// </summary>
        /// <returns>A collection of type IEnumerable</returns>
        public virtual IEnumerable<T> All()
        {
            return this.dbset.ToList();
        }

        /// <summary>
        /// Updates an existing entity instance in the database on behalf of the parent type.
        /// </summary>
        public void Update(T entity)
        {
            this.dbset.Attach(entity);
            this.db.Entry(entity).State = System.Data.EntityState.Modified;
        }

        public void SaveChanges()               
        {
            var NoOfObjectsSaved = this.db.SaveChanges();
        }

    }
}
