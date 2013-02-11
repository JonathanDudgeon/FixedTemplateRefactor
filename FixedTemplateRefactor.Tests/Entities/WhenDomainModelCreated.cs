using FixedTemplateRefactor.DomainX.Entities;
using FixedTemplateRefactor.DomainX.FactoryInterfaces;
using FixedTemplateRefactor.DomainX.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedTemplateRefactor.Tests.Entities
{
    [TestClass]
    public class WhenCustomerCreated : SpecificationTestBase
    {
        private Customer customer;
        private ISpecification<string> postCodeAreaSpec;
        private ISpecification<string> postCodeFormatSpec;
        private ICustomerChildEntityFactory childEntityFactory;
        private string testComment;
        private PolicyStatuses testStatus;
        private string testName;
        private int testCustId;
        
        
        public override void UnderTheseConditions()
        {
            postCodeAreaSpec = MockRepository.GenerateMock<PostCodeAreaSpecification>();
            postCodeFormatSpec = MockRepository.GenerateMock<PostCodeFormatSpecification>();
            childEntityFactory = MockRepository.GenerateMock<ICustomerChildEntityFactory>();
            testStatus = PolicyStatuses.ApplicationPending;
            testComment = "testComment";
            testName = "bob";
            testCustId = 999;
         }

        public override void AndThisHappens()
        {
            customer = new Customer(postCodeAreaSpec, postCodeFormatSpec, childEntityFactory);
            customer.addresses.Add(new Address(true));
            customer.Advisor = new Advisor(SomeProfileIndicator.Risky);
            customer.ActiveInstruction = new AccountInstruction(testStatus, testComment);
            customer.Name = testName;
            customer.CustomerId = testCustId;
        }

        [TestMethod]
        public void ThenShouldBeFullyPopulated()
        {
            Assert.IsTrue(customer.addresses.Count == 1);
            Assert.IsTrue(customer.addresses[1].IsValid);
            Assert.IsNotNull(customer.Advisor);
            Assert.IsTrue(customer.Advisor.ProfileIndicator == SomeProfileIndicator.Risky);
            Assert.AreEqual(testCustId, customer.CustomerId);
            Assert.AreEqual(testName, customer.Name);
            Assert.AreEqual(testComment, customer.ActiveInstruction.Comment);
            Assert.AreEqual(testStatus, customer.ActiveInstruction.PolicyStatus);
        }
    }
}
