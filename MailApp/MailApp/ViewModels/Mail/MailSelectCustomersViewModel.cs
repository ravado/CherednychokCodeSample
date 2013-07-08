using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommonLibrary.DataModels;

namespace MailApp.ViewModels.Mail
{
    public class MailSelectCustomersViewModel : BaseViewModel
    {
        public MailSelectCustomersViewModel() 
        {
            Company = "";
            Customers = new List<CustomerDataModel>();
            SelectedDate = new DateTime();
        }

        public string Company { get; set; }
        public List<CustomerDataModel> Customers { get; set; }
        public DateTime SelectedDate { get; set; }
    }
}