
namespace FixedTemplateRefactor.DomainX.DBContext
{
    public interface IDomainXDatabaseFactory
    {
        DomainXDBContext GetDBContext();
    }
}
