using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MailApp.ViewModels.Customer;
using CommonLibrary.Services;
using CommonLibrary.DataModels;

namespace MailApp.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        //
        // GET: /Customers/

        public ActionResult Index()
        {
            CustomerIndexViewModel viewModel = new CustomerIndexViewModel();
            CustomerService cService = new CustomerService();
            viewModel.Customers = cService.GetCustomers();

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            CustomerAddViewModel viewModel = new CustomerAddViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(CustomerAddViewModel viewModel)
        {
            if (TryUpdateModel(viewModel))
            {
                CustomerAddViewModel model = new CustomerAddViewModel();
                CustomerService cService = new CustomerService();
                cService.Add(viewModel.NewCustomer);
                model.Message = "Customer was added";
                return View(model);
            }

            return View(new CustomerAddViewModel());
        }
    }
}

