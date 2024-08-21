using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using WebDevelopmentPractice.DBConnection;
using WebDevelopmentPractice.IRepository;
using WebDevelopmentPractice.Models;

namespace WebDevelopmentPractice.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly DbConnection dbConnection;

        public CityRepository()
        {
            dbConnection = new DbConnection();
        }
        


    }
}
