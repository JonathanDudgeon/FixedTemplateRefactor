using FixedTemplateRefactor.DomainX.DBContext;
using FixedTemplateRefactor.DomainX.Entities;
using FixedTemplateRefactor.DomainX.FactoryInterfaces;
using FixedTemplateRefactor.DomainX.RepositoryInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using FixedTemplateRefactor.DomainX.Services;


namespace FixedTemplateRefactor.DomainX.Repositories
{
    /// <summary>
    /// customer is a composite enity
    /// </summary>
    public class CustomerRepository : DomainXRepositoryBase<Customer>, ICustomerRepository
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(CustomerRepository));
        private ICustomerFactory custfactory;

        public CustomerRepository(IDomainXDBContextFactory databaseFactory, ICustomerFactory customerFactory)
            : base(databaseFactory)
        {
            this.custfactory = customerFactory;
        }

        /// <summary>
        /// Adds a new entity instance to the database on behalf of the parent type.
        /// </summary>
        public Customer CreateNew()
        {
            log.DebugLogIfEnabled("new Customer instance requested from repository");
            Customer newCust = this.custfactory.getInstance();
            this.Add(newCust);
            return newCust;
        }
    }
}