using FixedTemplateRefactor.DomainX.Entities;

namespace FixedTemplateRefactor.DomainX.RepositoryInterfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        // extend with custom queries
    }
}
