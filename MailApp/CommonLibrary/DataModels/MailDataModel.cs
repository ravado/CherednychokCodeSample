using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary.DataModels
{
    /// <summary>
    /// Mail Data Model
    /// </summary>
    /// <author>Evgeny Drapoguz</author>
    /// <date>15 April 2013</date>
    public class MailDataModel
    {
        #region Fields
        private string _emailAddress;
        private string _subject;
        private string _body;
        #endregion

        #region Property
        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }
        #endregion

        #region Constructors
        public MailDataModel()
        {

        }

        public MailDataModel(string emailAddress, string subject, string body)
        {
            _emailAddress = emailAddress;
            _subject = subject;
            _body = body;
        }
        #endregion
    }
}
