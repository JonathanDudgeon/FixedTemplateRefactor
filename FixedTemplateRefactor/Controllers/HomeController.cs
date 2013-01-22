
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

            // TODO pass in entities to view, hardcoded to seeded test data for the moment
            var cust = this.custRepository.GetById(1);
            return this.View();
        }

        public ActionResult About()
        {
            return this.View();
        }
    }
}
