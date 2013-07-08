using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MailApp.ViewModels;
using CommonLibrary.Services;
using CommonLibrary.DataModels;
using CommonLibrary;
using System.Threading;
using MailApp.ViewModels.Mail;

namespace MailApp.Controllers
{
    [Authorize]
    public class MailController : Controller
    {
        //
        // GET: /Mail/

        public ActionResult Index()
        {
            return RedirectToAction("SelectCustomers");
        }


        [HttpGet]
        public ActionResult SelectCustomers()
        {
            MailSelectCustomersViewModel viewModel = new MailSelectCustomersViewModel();
            CustomerService cService = new CustomerService();
            viewModel.Customers = cService.GetCustomers();

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult WriteLetter()
        {
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult WriteLetter(FormCollection collection)
        {
            // select id of every checked customer
            int[] checkedCustomersId = collection.GetValues("id_customer").Select(n => Convert.ToInt32(n)).ToArray();

            CustomerService cService = new CustomerService();

            MailWriteLetterViewModel viewModel = new MailWriteLetterViewModel();
            viewModel.CustomersToSend = cService.GetCustomers(c => checkedCustomersId.Contains(c.Id));
            TempData["CustomersToSend"] = viewModel.CustomersToSend;

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult SendMail() {
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SendMail(MailWriteLetterViewModel viewModel)
        {
            List<CustomerDataModel> customers = (List<CustomerDataModel>)TempData["CustomersToSend"];
            List<string> emails = (from c in customers
                                   select c.Email).ToList<string>();

            // send mails in second thread
            Thread thread = new Thread(delegate() { Mailer.SendMail(emails, viewModel.Title, viewModel.Text); });
            thread.Start();
            

            return View(new MailSendViewModel());
        }



        #region Ajax
        
        public JsonResult AutocompleteCompanies(string term)
        {
            CustomerService cService = new CustomerService();
            var result = cService.GetCompanyNames(term);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult FilterCustomers(string company)
        {
            try
            {
                CustomerService cService = new CustomerService();
                List<CustomerDataModel> customers;
                if (company == "")
                {
                    customers = cService.GetCustomers();
                }
                else
                {
                    customers = cService.GetCustomers(company);
                }


                return Json(customers, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }

        #endregion
    }
}
