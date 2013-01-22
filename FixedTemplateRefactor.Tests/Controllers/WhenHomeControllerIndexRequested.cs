using FixedTemplateRefactor.Controllers;
using FixedTemplateRefactor.DomainX.RepositoryInterfaces;
using FixedTemplateRefactor.Tests.BLL.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Rhino.Mocks;
using FixedTemplateRefactor.DomainX.FactoryInterfaces;
using FixedTemplateRefactor.DomainX.DBContext;

namespace FixedTemplateRefactor.Tests.Controllers
{
    [TestClass]
    public class WhenHomeControllerIndexRequested : SpecificationTestBase
    {
        private ViewResult result;
        private HomeController controller;
        private ICustomerRepository custRepository;
        private int firstCustomerID = 1;

        public override void UnderTheseConditions()
        {
            // Arrange
            var databasefactory = MockRepository.GenerateMock<IDomainXDatabaseFactory>();
            var custFactory = MockRepository.GenerateMock<ICustomerFactory>();
            custRepository = MockRepository.GenerateMock<ICustomerRepository>();
            controller = new HomeController(custRepository); 
        }

        public override void AndThisHappens()
        {
            //Act
            result = controller.Index() as ViewResult;
        }

        [TestMethod]
        public void ThenExpectValue()
        {
            // Assert
            Assert.IsNotNull(result);
            custRepository.AssertWasCalled(x => x.GetById(firstCustomerID));
        }
    }
}
