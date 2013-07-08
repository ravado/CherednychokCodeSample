using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonLibrary.Services;
using CommonLibrary.DataModels;
using MailApp.ViewModels.Home;

namespace MailApp.Controllers
{    
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        
        public ActionResult Index()
        {
            HomeIndexViewModel viewModel = new HomeIndexViewModel();
            viewModel.Title = "Mail Sender";
            return View(viewModel);
        }
    }
}
