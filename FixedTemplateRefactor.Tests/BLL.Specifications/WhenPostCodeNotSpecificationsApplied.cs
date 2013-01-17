using FixedTemplateRefactor.DomainX.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FixedTemplateRefactor.Tests.BLL.Specifications
{
    [TestClass]
    public class WhenPostCodeNotSpecificationsApplied : SpecificationTestBase
    {
        PostCodeAreaSpecification spec1 = new PostCodeAreaSpecification();
        PostCodeFormatSpecification spec2 = new PostCodeFormatSpecification();
        ISpecification<string> formatedButNotInAreaSpec = null;

        private bool expectedResult = false;
        private string testSubject ="aValue";

        public override void UnderTheseConditions()
        {
             spec1 = new PostCodeAreaSpecification();
             spec2 = new PostCodeFormatSpecification();
             formatedButNotInAreaSpec = spec2.And(spec1.Not());
        }

        public override void WhenThisHappens()
        {
            expectedResult = formatedButNotInAreaSpec.IsSatisfiedBy(testSubject);
        }

        [TestMethod]
        [Description("Specification 'Not' composition test")]
        public void ShouldReturnFalse()
        {
            Assert.IsFalse(expectedResult, "Specs are hardcoded to true for demo purposes so 'Not' should fail");
        }
    }
}
