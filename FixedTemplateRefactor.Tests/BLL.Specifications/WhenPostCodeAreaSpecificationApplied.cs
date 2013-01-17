using FixedTemplateRefactor.DomainX.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FixedTemplateRefactor.Tests.BLL.Specifications
{
    [TestClass]
    public class WhenPostCodeAreaSpecificationApplied : SpecificationTestBase
    {
        PostCodeFormatSpecification spec1 = new PostCodeFormatSpecification();

        private bool expectedResult = false;
        private string testSubject ="aValue";

        public override void UnderTheseConditions()
        {
            spec1 = new PostCodeFormatSpecification();
        }

        public override void WhenThisHappens()
        {
            expectedResult = spec1.IsSatisfiedBy(testSubject);
        }

        [TestMethod]
        public void ShouldReturnTrue()
        {
            Assert.IsTrue(expectedResult, "Specs are hardcoded to true for demo purposes");
        }
    }
}
