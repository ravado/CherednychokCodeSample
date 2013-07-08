﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommonLibrary.DataModels;

namespace MailApp.ViewModels.Mail
{
    public class MailWriteLetterViewModel : BaseViewModel
    {
        public string Header { get; set; }
        public string Text { get; set; }
        public List<CustomerDataModel> CustomersToSend { get; set; }
    }
}