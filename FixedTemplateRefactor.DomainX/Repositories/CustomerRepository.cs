using FixedTemplateRefactor.DomainX.DBContext;
using FixedTemplateRefactor.DomainX.Entities;
using FixedTemplateRefactor.DomainX.FactoryInterfaces;
using FixedTemplateRefactor.DomainX.RepositoryInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FixedTemplateRefactor.DomainX.Repositories
{
    /// <summary>
    /// customer is a composite enity
    /// </summary>
    public class CustomerRepository : DomainXRepositoryBase<Customer>, ICustomerRepository
    {
        private ICustomerFactory custfactory;

        public CustomerRepository(IDomainXDatabaseFactory databaseFactory, ICustomerFactory customerFactory)
            : base(databaseFactory)
        {
            this.custfactory = customerFactory;
        }

        /// <summary>
        /// Adds a new entity instance to the database on behalf of the parent type.
        /// </summary>
        public Customer CreateNew()
        {
            Customer newCust = this.custfactory.getInstance();
            this.Add(newCust);
            return newCust;
        }

        public IEnumerable<Customer> SearchAddress(string Description)
        {
            //TODO: HOOK UP QUERY
           /// return this.CustomerDb.Customers.Where(t => t....);
            return null;
        }
    }
}