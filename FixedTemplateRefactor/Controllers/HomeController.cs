
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
﻿using FixedTemplateRefactor.DomainX.RepositoryInterfaces;
using System.Web.Mvc;
using FixedTemplateRefactor.DomainX.Entities;
using log4net;

namespace FixedTemplateRefactor.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerRepository custRepository;

        public HomeController(ICustomerRepository custRepository)
        {
            this.custRepository = custRepository ;

        }
           
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            Customer cust = custRepository.CreateNew();
            cust.AddAddressBy("APostCode");
            cust.Profile = new Profile(Profile.SomeProfileIndicator.Balanced);
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
