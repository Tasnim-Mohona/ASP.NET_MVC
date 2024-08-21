/*using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using WebDevelopmentPractice.Models;

namespace WebDevelopmentPractice.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Audit()
        {
            // Creating an instance of the Person class
            Person person = new Person
            {
                FirstName = "Quazi",
                LastName = "Mohona",
                Age = 26
            };
            ViewBag.Message = "Your application description page.";
            ViewBag.Person = person;
            return View(person);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [OutputCache(Duration = 0, NoStore = true)]
        public ActionResult Error()
        {
            var requestId = HttpContext.Items["RequestId"]?.ToString() ?? Guid.NewGuid().ToString();
            var errorViewModel = new ErrorViewModel
            {
                RequestId = requestId
            };
            return View(errorViewModel);
        }

        [HttpGet]
        public JsonResult GetCities(string country)
        {
            List<string> cities = new List<string>();

            switch (country)
            {
                case "Bangladesh":
                    cities.AddRange(new List<string> { "Dhaka", "Chittagong", "Sylhet" });
                    break;
                case "India":
                    cities.AddRange(new List<string> { "Delhi", "Mumbai", "Kolkata" });
                    break;
                case "Japan":
                    cities.AddRange(new List<string> { "Tokyo", "Osaka", "Kyoto" });
                    break;
                default:
                    break;
            }

            return Json(cities, JsonRequestBehavior.AllowGet);
        }
    }
}

*/



using System.Collections.Generic;
using System.Web.Mvc;
using WebDevelopmentPractice.Repository;
using WebDevelopmentPractice.Models;

namespace WebDevelopmentPractice.Controllers
{
    public class HomeController : Controller
    {
       // private readonly CityRepository cityRepository;

        private readonly CountryRepository countryRepository;

        public HomeController()
        {
           // cityRepository = new CityRepository();
            countryRepository = new CountryRepository();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Your Home page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }


        [HttpGet]
        public ActionResult Audit()
        {
            ViewBag.Message = "Your Audit Page.";
            return View();
        }

        public JsonResult GetCountries()
        {
            List<CountryModel> countries = countryRepository.GetCountry();
            return Json(countries, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetCities(string countryId) 
        {
            if (countryId is null || countryId =="")
            {
                return Json(new List<string>(), JsonRequestBehavior.AllowGet);
            }

            List<CityModel> cities = countryRepository.GetCitiesByCountryId(countryId);  

            return Json(cities, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]

        public JsonResult GetPostcodes(string cityId)
        {
            if (cityId is null || cityId == "")
            {
                return Json(new List<string>(), JsonRequestBehavior.AllowGet);

            }

            List<CityModel> postcodes = countryRepository.GetPostcodesByCityId (cityId);

            return Json(postcodes, JsonRequestBehavior.AllowGet);

        }

    }

}
