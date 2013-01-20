using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedTemplateRefactor.DomainX.FactoryInterfaces
{
    // todo
    public interface IEntityFactory<TEntity>
    {
        TEntity GetInstance();
    }
}
