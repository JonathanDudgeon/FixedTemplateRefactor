using FixedTemplateRefactor.DomainX.Entities; 

namespace FixedTemplateRefactor.DomainX.FactoryInterfaces
{
    public interface ICustomerFactory
    {
        Customer getInstance();

        void AssertWasCalled(System.Func<ICustomerFactory, object> func);
    }
}
