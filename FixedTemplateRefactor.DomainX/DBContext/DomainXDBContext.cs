using FixedTemplateRefactor.DomainX.Entities;
using System.Data.Entity;

namespace FixedTemplateRefactor.DomainX.DBContext
{
    /// <summary>
    /// Provides facilities for querying and working with entity data as objects.
    /// </summary>
    /// <remarks>
    /// A DBContext Represents a combination of the Unit-Of-Work and Repository patterns and 
    /// enables you to query a database and group together changes that will then be written
    /// back to the store as a unit. DbContext is conceptually similar to ObjectContext.
    /// 
    /// TODO Note that a section of code has been commented out in this class that allows
    /// dynamic dropping and recreation of the data model (i.e. the database) but does 
    /// not currently seed the newly-created database with new data.
    /// </remarks>
    public class DomainXDBContext : DbContext
    {
        private IDbSet<Customer> customers;

        /// <summary>
        /// Returns a DbSet that allows CRUD 
        /// operations to be performed for the given Aggragate entity in the context. 
        /// </summary>
        public IDbSet<Customer> Customers
        {
            get 
            { 
                return this.customers ?? (this.customers = this.DbSet<Customer>()); 
            }
        }

        /// <summary>
        /// Returns a DbSet for the specified type, this allows CRUD operations to be performed for 
        /// the given entity in the context.  
        /// </summary>
        public virtual IDbSet<T> DbSet<T>() where T : class
        {
            return this.Set<T>();
        }
    
        // Composed types
        public virtual IDbSet<Address> Addresses { get; set; }

        public DomainXDBContext()
        {}

        public DomainXDBContext(string connectionString)
            : base(connectionString)
        {
            this.customers = this.Customers;
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database. 
        /// </summary>
        public virtual void Commit()
        {
            this.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Database.SetInitializer<DomainXDBContext>(new DomainXContextInitialiser());
        }
    }
}