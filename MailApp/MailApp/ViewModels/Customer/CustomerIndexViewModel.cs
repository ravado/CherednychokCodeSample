using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommonLibrary.DataModels;

namespace MailApp.ViewModels.Customer
{
    public class CustomerIndexViewModel:BaseViewModel
    {
        public List<CustomerDataModel> Customers { get; set; }
    }
}