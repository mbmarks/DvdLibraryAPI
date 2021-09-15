using DvdLibraryWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DvdLibraryWebApi.Models
{
    public class DvdRepositoryFactory
    {
        public static IDvdRepository Create()
        {
            string repositoryType = ConfigurationManager.AppSettings["Mode"].ToString();

            if (repositoryType == "SampleData")
                return new DvdRepositoryMock();
            else if (repositoryType == "ADO")
                return new DvdRepositoryADO();
            else
                throw new Exception("Repository Type in Web.config not set properly!");
        }
    }
}