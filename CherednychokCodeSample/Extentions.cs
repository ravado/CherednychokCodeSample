using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CommonLibrary
{
    public static class Extentions
    {

        public static bool HasConnectionString(this ConnectionStringSettingsCollection value, string key)
        {
            try
            {
                return value[key].ConnectionString.Length > 0;
            }
            catch
            {
                return false;
            }
        }
    }
    
}
