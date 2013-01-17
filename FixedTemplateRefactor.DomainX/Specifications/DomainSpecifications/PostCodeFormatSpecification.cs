
namespace FixedTemplateRefactor.DomainX.Specifications
{
    /// <summary>
    /// made up rule for purposes of demo of spec chaining
    /// </summary>
    public class PostCodeFormatSpecification : ISpecification<string>
    {
        public bool IsSatisfiedBy(string entity)
        {
            // apply logic
            return true;
        }
    }
}
