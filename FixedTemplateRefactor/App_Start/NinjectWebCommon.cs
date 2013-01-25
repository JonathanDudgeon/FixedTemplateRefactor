using FixedTemplateRefactor.DomainX.DBContext;
using FixedTemplateRefactor.DomainX.Entities;
using FixedTemplateRefactor.DomainX.FactoryInterfaces;
using FixedTemplateRefactor.DomainX.Repositories;
using FixedTemplateRefactor.DomainX.RepositoryInterfaces;
using FixedTemplateRefactor.DomainX.Specifications;
using Ninject.Extensions.Factory;


// avoid cluttering up global.asx with further concerns with use of WebActivator.  IOC is an ideal candidate for activation
// is it sits above an application conceptually.
[assembly: WebActivator.PreApplicationStartMethod(typeof(FixedTemplateRefactor.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(FixedTemplateRefactor.App_Start.NinjectWebCommon), "Stop")]
namespace FixedTemplateRefactor.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using System;
    using System.Web;
    

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        ///  IOC initialisation
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        { 
            // WIP, add in some examples of context binding
            kernel.Bind<IDomainXDBContextFactory>().To<DomainXDBContextFactory>();
            kernel.Bind<ICustomerFactory>().ToFactory();

            kernel.Bind<ICustomerRepository>().To<CustomerRepository>();

            // we have 2 implementations of ispec injected into the same constructor so using 
            // a bit of convention to resolve
            //pCodeAreaSpec, ISpecification<string> pCodeFormatSpec
            kernel.Bind(typeof(ISpecification<>)).To(
                typeof(PostCodeAreaSpecification)).Named("PostCodeAreaSpecRequiredAttribute");
            kernel.Bind(typeof(ISpecification<>)).To(
                typeof(PostCodeFormatSpecification)).Named("PostCodeFormatSpecRequiredAttribute");

            kernel.Bind<ICustomerChildEntityFactory>().ToFactory();
        }        
    }
}
              
