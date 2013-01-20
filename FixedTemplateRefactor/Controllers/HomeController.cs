
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
﻿using FixedTemplateRefactor.DomainX.RepositoryInterfaces;
using System.Web.Mvc;
using FixedTemplateRefactor.DomainX.Entities;

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

            // lets play with repository
            try
            {
                Customer cust = custRepository.CreateNew();

                //Customer existingCust = custRepository.GetById(2);
           
               cust.AddAddressBy("aPostCode");
           
               custRepository.SaveChanges();
      
            }
            catch (Exception ex)
            {
                
            }
           
            return this.View();
        }

        public ActionResult About()
        {
            return this.View();
        }
    }
}
