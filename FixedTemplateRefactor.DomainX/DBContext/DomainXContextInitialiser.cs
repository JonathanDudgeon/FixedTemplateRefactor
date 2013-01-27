using FixedTemplateRefactor.DomainX.Entities;
using System.Data.Entity;

namespace FixedTemplateRefactor.DomainX.DBContext
{
    /// <summary>
    /// The Initialiser class defines the behaviour for recreating the CustomerDB data structure and seeds 
    /// the database with the default values required for the application to run.
    /// </summary>
    public class DomainXContextInitialiser : DropCreateDatabaseAlways<DomainXDBContext>
    {
        protected override void Seed(DomainXDBContext context)
        {
            // add initial dummy data here if required for testing.
    
        }
    }
}
