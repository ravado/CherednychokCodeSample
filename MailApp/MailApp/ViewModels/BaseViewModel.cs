using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MailApp.ViewModels
{
    public class BaseViewModel
    {
        public string Title { get; set; }
        public bool IsAuthorized { get; set; }

        public BaseViewModel() {
            Title = "";
            IsAuthorized = false;
        }
    }
}