using DAL;
using Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PhoneBookUI.Models;
using System;
using System.Diagnostics;

namespace PhoneBookUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly UnitOfWorks _dal =UnitOfWorks.Instance;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Person> persons = _dal.PersonRepository.GetAll().ToList();
            List<Person> personForViewBag= new List<Person>();
            foreach (Person person in persons) { 
                City city = _dal.CityRepository.GetById(person.CityId);
                District district = _dal.DistrictRepository.GetById(person.DistrictId);
                person.City = city;
                person.District = district;
                personForViewBag.Add(person);
            }
            ViewBag.Persons = personForViewBag;

            var cityListDropDown = new List<SelectListItem>();
            foreach (City city in _dal.CityRepository.GetAll()) {
                cityListDropDown.Add(new SelectListItem { Text = city.Name, Value = city.Id.ToString() });
            }
            ViewBag.City =cityListDropDown ;

            return View();
        }
        
        [HttpPost]
        public JsonResult GetDistrictById(int id)
        {
            List<District> lstDistrict = _dal.DistrictRepository.GetByCityId(id).ToList();
            var districtListDropDown = "<select class=\"form-select\" id=\"drpDistrict\">";
            foreach (District district in lstDistrict)
            {
                districtListDropDown += "<option value=\""+district.Id+"\">"+district.Name+"</option>";
                //districtListDropDown.Add(new SelectListItem { Text = district.Name, Value = district.Id.ToString() });
            }
            districtListDropDown += "</select>";
            JsonResult res = Json(districtListDropDown);
            return res;
        }

        [HttpPost]
        public ActionResult SavePerson(Person person)
        {
            if (person != null)
            {
                if (person.Id != 0)
                {
                    Person pers=_dal.PersonRepository.GetById(person.Id);
                    pers.PhoneNumber = person.PhoneNumber;
                    pers.SurName    = person.SurName;
                   // pers.UpdatedDate = DateTime.Now;
                    pers.CityId = person.CityId;    
                    pers.DistrictId = person.DistrictId;
                    pers.Name = person.Name;    
                    
                    _dal.PersonRepository.Update(pers);
                }
                else
                {
                    _dal.PersonRepository.Add(person);
                }
                _dal.Complate();
            }
            return View();
        }

        [HttpGet]
        public JsonResult GetPerson(int Id)
        {
            Person person= _dal.PersonRepository.GetById(Id);
            JsonResult res = Json(person);
            return res;
        }

        [HttpPost]
        public JsonResult DeletePerson(int Id)
        {
            try
            {
                _dal.PersonRepository.Remove(Id);
                _dal.Complate();
                return Json("Silme İşlemi Gerçekleşti");
            }
            catch (Exception ex)
            {

                return Json("Silme İşlemi Sırasında Hata İle Karşılaşıldı : "+ex.Message);
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}