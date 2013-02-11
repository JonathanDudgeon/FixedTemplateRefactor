using FixedTemplateRefactor.DomainX.DBContext;
using FixedTemplateRefactor.DomainX.RepositoryInterfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using log4net;
using FixedTemplateRefactor.DomainX.Services;
using System.Threading.Tasks;

namespace FixedTemplateRefactor.DomainX.Repositories
{
    public abstract class DomainXRepositoryBase<T> : IRepository<T> where T : class
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DomainXRepositoryBase<>));
        private readonly IDbSet<T> dbset;
        private DomainXDBContext db;

        /// <summary>
        /// Holds a reference to the DatabaseFactory class used to manage connections to the database.
        /// </summary>
        protected IDomainXDBContextFactory DatabaseFactory
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

        public DomainXRepositoryBase(IDomainXDBContextFactory dbFactory)
        {
            this.DatabaseFactory = dbFactory;
            this.dbset = this.CustomerDb.Set<T>();
        }

        /// <summary>
        /// Adds a new entity instance to the database on behalf of the parent type.
        /// </summary>                                  
        public virtual void Add(T entity)
        {
            if (entity == null) 
            {
                log.Error("Add to customer Repository requested with a null arguement");
                throw new System.ArgumentNullException();
            }

            log.DebugLogIfEnabled("Add To repository requested..");
            this.dbset.Add(entity);
            log.DebugLogIfEnabled("Add Request complete");
        }

        /// <summary>
        /// 
        /// Deletes an existing instance of an entity from the database on behalf of the parent type.
        /// </summary>
        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                log.Error("Delete from customer repository requested with a null arguement, no exception thrown");
                return;
            }

            log.DebugLogIfEnabled("Delete from Repository requested for Entity " + entity.ToString());
            this.dbset.Remove(entity);
            log.DebugLogIfEnabled("Delete request completed");
        }

        /// <summary>
        /// Returns a specific instance of an entity from the database on behalf of the parent type.
        /// </summary>
        /// <param name="id">The integer value of the entity's primary key</param>
        public virtual T GetById(int id)
        {
            log.DebugLogIfEnabled("GetByID requested with ID " + id);
            return this.dbset.Find(id);
        }

        /// <summary>
        /// Returns an IEnumerable collection of all objects found in the database of type T
        /// </summary>
        /// <returns>A collection of type IEnumerable</returns>
        public virtual IEnumerable<T> All()
        {
            log.DebugLogIfEnabled("Reposirory All method invoked");
            return this.dbset.ToList();
        }

        /// <summary>
        /// Updates an existing entity instance in the database on behalf of the parent type.
        /// </summary>
        public void Update(T entity)
        {
            if (entity == null)
            {
                log.Error("Repository update invoked with a null arguement, exception raised");
                throw new System.ArgumentNullException();
            }

            log.DebugLogIfEnabled("Update Requested for Entity " + entity.ToString());
            this.dbset.Attach(entity);
            this.db.Entry(entity).State = System.Data.EntityState.Modified;
            log.DebugLogIfEnabled("Update requested completed");
        }

        public void SaveChanges()               
        {
            log.DebugLogIfEnabled("Save requested for repository..");
            var NoOfObjectsSaved = this.db.SaveChanges();
            log.DebugLogIfEnabled("Save changes requested completed");
        }
    }
}
