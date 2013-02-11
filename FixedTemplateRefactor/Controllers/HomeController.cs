
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
﻿using FixedTemplateRefactor.DomainX.RepositoryInterfaces;
using System.Web.Mvc;
using FixedTemplateRefactor.DomainX.Entities;
using log4net;
using FixedTemplateRefactor.DomainX.Services;
using System.Threading.Tasks;
using System.Net.Http;

namespace FixedTemplateRefactor.Controllers
{
    public class HomeController : AsyncController
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(HomeController));

        private ICustomerRepository custRepository;

        public HomeController(ICustomerRepository custRepository)
        {
            this.custRepository = custRepository ;
        }

        public ActionResult Index()
        {
            log.DebugLogIfEnabled("Index Action..");
            //ViewBag.SyncOrAsync = "Asynchronous";
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            // -----------------------------------------------
            // using repository here, but we would ofc not be 
            // doing this on index action
            // note create customer has some async behaviour
            // but eventually waits and returns void so no need for consumer
            // of method to worry about this
            // -----------------------------------------------

            CreateCustomer();
            
            //var cust2 = this.custRepository.GetById(1);

            return this.View();
        }

        public ActionResult About()
        {
            return this.View();
        }

        private async void CreateCustomer()
        {
            Task<Boolean> result = ConnectToSomeSite();
            
            // lets do some stuff while my async method is processing
            Customer cust = custRepository.CreateNew();
            cust.AddAddressBy("APostCode");
            cust.ActiveInstruction = new AccountInstruction(
               PolicyStatuses.NoActiveAccount,
              "Customer advises this is a test");

            custRepository.Add(cust);

            custRepository.SaveChanges();

            // now wait for async result
            Boolean boolResult = await result; 
        }

        private async Task<Boolean> ConnectToSomeSite()
        {
            var httpClient = new HttpClient();
            // At the await expression, execution in this method is suspended, and
            // control returns to the caller of ExampleMethodAsync.
            // Variable exampleInt is assigned a value when GetStringAsync completes.
            int exampleInt = (await httpClient.GetStringAsync("http://msdn.microsoft.com")).Length;

            return true;
        }


    }
}
