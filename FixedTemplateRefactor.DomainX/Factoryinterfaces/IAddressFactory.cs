using FixedTemplateRefactor.DomainX.Entities;

namespace FixedTemplateRefactor.DomainX.FactoryInterfaces
{
    public interface IAddressFactory
    {
        // note maning conventions used here, param name should match target constructor
        // (any order)
        Address getInstance(bool isAddressValid);
    }
}
