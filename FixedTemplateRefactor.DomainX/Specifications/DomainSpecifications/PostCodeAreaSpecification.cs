
namespace FixedTemplateRefactor.DomainX.Specifications
{
    /// <summary>
    /// dummy rule for purposes of demo of spec chaining
    /// </summary>
    public class PostCodeAreaSpecification : ISpecification<string>
    {
        public bool IsSatisfiedBy(string entity)
        {
            // apply logic
            return true;
        }
    }
}
