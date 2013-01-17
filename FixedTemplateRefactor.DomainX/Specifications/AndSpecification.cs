namespace FixedTemplateRefactor.DomainX.Specifications
{
    internal class AndSpecification<TEntity> : ISpecification<TEntity>
    {
        private ISpecification<TEntity> spec1;
        private ISpecification<TEntity> spec2;

        internal AndSpecification(ISpecification<TEntity> s1, ISpecification<TEntity> s2)
        {
            this.spec1 = s1;
            this.spec2 = s2;
        }

        public bool IsSatisfiedBy(TEntity candidate)
        {
            return this.spec1.IsSatisfiedBy(candidate) && this.spec2.IsSatisfiedBy(candidate);
        }
    }
}
