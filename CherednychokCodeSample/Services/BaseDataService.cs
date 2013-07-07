using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using ResourcesLibrary;
using CherednychokCodeSample;

namespace CommonLibrary.Services
{
    /// <summary>
    /// Basic service for data
    /// </summary>    
    /// <date>22 April 2013</date>
    public class BaseDataService
    {
        private const string CONNECTION_STRING_PROPERTY_NAME = "ScientiaPotentiaEstEntities";
        private const string CONNECTION_STRING_SQL_PROPERTY_NAME = "SqlConnectionString";

        protected ScientiaPotentiaEstEntities GetContext()
        {

            if (ConfigurationManager.ConnectionStrings.HasConnectionString(CONNECTION_STRING_PROPERTY_NAME))
            {
                string connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_STRING_PROPERTY_NAME].ConnectionString;
                
                return new ScientiaPotentiaEstEntities(connectionString);
            }
            else
            {
                throw new Exception(string.Format(Errors.ConStringMissedApp, CONNECTION_STRING_PROPERTY_NAME));
            }
        }

    }
}
