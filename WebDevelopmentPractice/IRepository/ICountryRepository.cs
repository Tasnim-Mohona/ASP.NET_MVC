using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDevelopmentPractice.Models;


namespace WebDevelopmentPractice.IRepository
{
    interface ICountryRepository
    {
        List<CountryModel> GetCountry();
        List<CityModel> GetCitiesByCountryId(string countryId);
    }
}
