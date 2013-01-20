using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedTemplateRefactor.DomainX.FactoryInterfaces
{
    public class TestGenericFactory
    {
        private IEntityFactory<object> fact;
        public TestGenericFactory(IEntityFactory<object> entityFactory)
        {
            fact = entityFactory;
        }
    }
}
