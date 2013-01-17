using FixedTemplateRefactor.DomainX.Entities;

namespace FixedTemplateRefactor.DomainX.FactoryInterfaces
{
    public interface IAddressFactory
    {
        Address getInstance(bool isValid);
    }
}
