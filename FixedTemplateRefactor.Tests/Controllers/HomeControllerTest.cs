using FixedTemplateRefactor.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace FixedTemplateRefactor.Tests.Controllers
{
    /// <summary>
    /// default generated test
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
        
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController(null);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
