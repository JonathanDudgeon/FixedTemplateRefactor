
namespace FixedTemplateRefactor.DomainX.Specifications
{
    internal class NotSpecification<TEntity> : ISpecification<TEntity>
    {
        private ISpecification<TEntity> wrapped;

        internal NotSpecification(ISpecification<TEntity> x)
        {
            this.wrapped = x;
        }

        public bool IsSatisfiedBy(TEntity candidate)
        {
            return !this.wrapped.IsSatisfiedBy(candidate);
        }
    }
}
