using FixedTemplateRefactor.DomainX.Entities;
using System.Collections.Generic;

namespace FixedTemplateRefactor.DomainX.RepositoryInterfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        /// <summary>
        /// Adds a new entity instance to the database on behalf of the parent type.
        /// </summary>
        Customer CreateNew();

        //IEnumerable<Customer> SearchAddress(string Description);
    }
}
