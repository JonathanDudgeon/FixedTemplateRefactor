using System.Configuration;

namespace FixedTemplateRefactor.DomainX.DBContext
{
    /// The DatabaseFactory class is the proxy manager for all connections and transactions with the database. /// 
    /// 
    /// This class is responsible for the actual connection to the database. It holds the reference to the actual 
    /// database connection string from Web.Config.
    /// 
    public class DomainXDBContextFactory : Disposable, IDomainXDatabaseFactory
    {
        private DomainXDBContext db;

        /// Returns the active database object context instance or creates a new instance if one doesn't exist /// already. /// 
        /// A CustomerDBContext object (which inherits from DbContext).
        public DomainXDBContext GetDBContext()
        {
            return this.db ?? (this.db = new DomainXDBContext(ConfigurationManager.ConnectionStrings["DomainX"].ConnectionString));
        }

        protected override void DisposeCore()
        {
            if (this.db != null)
            {
                this.db.Dispose();
            }
        }
    }
}
