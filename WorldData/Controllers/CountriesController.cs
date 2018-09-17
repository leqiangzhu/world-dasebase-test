using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using WorldData.Models;

namespace WorldData.Controllers
{
  public class CountriesController : Controller
  {
    [HttpGet("/countries")]
    public ActionResult Index()
    {
     List <Country> allCountries = Country.GetAllCountry();

      return View(allCountries);
    }

    [HttpPost("/countries")]
    public ActionResult Sort()
    {
      List<Country> allCountries = Country.GetCountrySortedBy(Request.Form["sortedby"],Request.Form["letter"]);
      return View("Index",allCountries);
    }


  }
}
