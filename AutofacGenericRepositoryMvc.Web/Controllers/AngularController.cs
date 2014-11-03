using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutofacGenericRepositoryMvc.Service.Interfaces;

namespace AutofacGenericRepositoryMvc.Web.Controllers
{
    public class AngularController : Controller
    {
        // GET: Angular
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PersonList()
        {
            return PartialView();
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        public ActionResult Detail()
        {
            return PartialView();
        }

        public ActionResult Edit()
        {
            return PartialView();
        }
    }
}