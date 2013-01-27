
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
﻿using FixedTemplateRefactor.DomainX.RepositoryInterfaces;
using System.Web.Mvc;
using FixedTemplateRefactor.DomainX.Entities;
using log4net;
using FixedTemplateRefactor.DomainX.Services;

namespace FixedTemplateRefactor.Controllers
{
    public class HomeController : Controller
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

            ViewBag.Message = "Welcome to ASP.NET MVC!";
            
            Customer cust = custRepository.CreateNew();                                                       
            cust.AddAddressBy("APostCode");
            cust.ActiveInstruction = new AccountInstruction(
                PolicyStatuses.NoActiveAccount,
                "Customer advises this is a test");
       
            custRepository.Add(cust);
            custRepository.SaveChanges();

            var cust2 = this.custRepository.GetById(1);
            return this.View();
        }

        public ActionResult About()
        {
            return this.View();
        }
    }
}
