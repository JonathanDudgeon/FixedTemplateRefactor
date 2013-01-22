using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FixedTemplateRefactor.Tests
{
    public abstract class SpecificationTestBase
    {
        [TestInitialize]
        public void Setup()
        {
            //Arrange & Act, Assert is defined in the subclasses
            UnderTheseConditions();
            AndThisHappens();
        }

        public abstract void UnderTheseConditions();
        public abstract void AndThisHappens();
    }
}
