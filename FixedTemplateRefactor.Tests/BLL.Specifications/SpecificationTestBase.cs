using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FixedTemplateRefactor.Tests.BLL.Specifications
{
    public abstract class SpecificationTestBase
    {
        [TestInitialize]
        public void Setup()
        {
            UnderTheseConditions();
            WhenThisHappens();
        }

        public abstract void UnderTheseConditions();
        public abstract void WhenThisHappens();
    }
}
