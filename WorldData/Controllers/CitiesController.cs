using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using WorldData.Models;

namespace WorldData.Controllers
{
  public class CitiesController : Controller
  {
    [HttpGet("/cities")]
    public ActionResult Index()
    {
       List <City> allCities = City.GetAllCity();

      return View(allCities);
      
    }
    [HttpPost("/cities")]
    public ActionResult Order()
    {
      string newOrder = Request.Form["order"].ToString();
      List<City> allCities = City.GetAllCityByPopulation(newOrder);
      return View("Index", allCities);
    }
  }
}

  