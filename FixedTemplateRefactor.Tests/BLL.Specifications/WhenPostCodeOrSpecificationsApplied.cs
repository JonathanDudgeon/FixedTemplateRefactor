using FixedTemplateRefactor.DomainX.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FixedTemplateRefactor.Tests.BLL.Specifications
{
    [TestClass]
    public class WhenPostCodeOrSpecificationsApplied : SpecificationTestBase
    {
        PostCodeAreaSpecification spec1 = new PostCodeAreaSpecification();
        PostCodeFormatSpecification spec2 = new PostCodeFormatSpecification();
        ISpecification<string> compositeAndSpec = null;

        private bool expectedResult = false;
        private string testSubject ="aValue";

        public override void UnderTheseConditions()
        {
             spec1 = new PostCodeAreaSpecification();
             spec2 = new PostCodeFormatSpecification();
             compositeAndSpec = spec1.Or(spec2);
        }

        public override void WhenThisHappens()
        {
            expectedResult = compositeAndSpec.IsSatisfiedBy(testSubject);
        }

        [TestMethod]
        [Description("Specification 'Or' composition tests")]
        public void ShouldReturnTrue()
        {
            Assert.IsTrue(expectedResult, "Specs are hardcoded to true for demo purposes");
        }
    }
}
