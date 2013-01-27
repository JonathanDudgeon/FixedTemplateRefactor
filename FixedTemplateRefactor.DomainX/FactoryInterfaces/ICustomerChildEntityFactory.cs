using FixedTemplateRefactor.DomainX.Entities;


namespace FixedTemplateRefactor.DomainX.FactoryInterfaces
{
    /// <summary>
    /// implemented by ninject.  Where binding cannot be determined at application composition 
    /// we can pass in a factory, while avoiding passing in the IOC kernel (and avoiding service locator anti pattern)
    /// </summary>
    public interface ICustomerChildEntityFactory
    {
        // note maning conventions used here, param name should match target constructor
        // (any order)
        Address createAddressInstance(bool isAddressValid);
        Advisor createProfileInstance(SomeProfileIndicator indicator);
    }
}
