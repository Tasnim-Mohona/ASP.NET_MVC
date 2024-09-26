using System;
using System.Collections.Generic;
using WebDevelopmentPractice.DataAccessLayer;
using WebDevelopmentPractice.IRepository;
using WebDevelopmentPractice.Models;


namespace WebDevelopmentPractice.Repository
{
    public class CountryRepository : ICountryRepository
    {
        public List<CountryModel> GetCountry()
        {
            List<CountryModel> objCountryList = null;
            try
            {
                objCountryList = new CountryCityInfoDb().GetCountry();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving country data: " + ex.Message, ex);
            }
            return objCountryList;
        }

        public List<CityModel> GetCitiesByCountryId(string countryId)
        {
            List<CityModel> objCityList = null;
            try
            {
                objCityList = new CountryCityInfoDb().GetCitiesByCountryId(countryId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving city data: " + ex.Message, ex);
            }
            return objCityList;
        }

        public List<CityModel> GetPostcodesByCityId (string cityId)
        {
            List<CityModel> objPostcodeList = null;
            try
            {
                objPostcodeList = new CountryCityInfoDb().GetPostcodesByCityId(cityId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving postcode data: " + ex.Message, ex);
            }
            return objPostcodeList;
        }


        public List<CityModel> GetAreasByPostcodeId(string postcode_Id)
        {
            List<CityModel> objAreaList = null;
            try
            {
                objAreaList = new CountryCityInfoDb().GetAreasByPostcodeId(postcode_Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving area data: " + ex.Message, ex);
            }
            return objAreaList;
        }

    }
}
