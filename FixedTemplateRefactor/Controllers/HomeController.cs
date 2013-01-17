
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
﻿using FixedTemplateRefactor.DomainX.RepositoryInterfaces;
using System.Web.Mvc;

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

            return this.View();
        }

        public ActionResult About()
        {
            return this.View();
        }
    }
}
