using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using CommonLibrary;

namespace CommonLibrary.Services
{   
    public class BaseService
    {
        private const string CONNECTION_STRING_PROPERTY_NAME = "MailStoredgeEntities";
        private const string CONNECTION_STRING_SQL_PROPERTY_NAME = "SqlConnectionString";

        public MailStoredgeEntities GetContext()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_STRING_PROPERTY_NAME].ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
                throw new Exception(string.Format("Connection string {0} is missed in web.config", CONNECTION_STRING_PROPERTY_NAME));
            return new MailStoredgeEntities(connectionString);
        }
    }
}
