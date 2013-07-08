using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommonLibrary.DataModels;

namespace MailApp.ViewModels.Customer
{
    public class CustomerAddViewModel:BaseViewModel
    {
        public CustomerDataModel NewCustomer { get; set; }
        public string Message { get; set; }
    }
}