using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldData;
using System;

namespace WorldData.Models
{
  public class City
  {
    public int _cityId{get;set;}
    public string _countyCode{get;set;}
    public string _cityName{get;set;}
    public int _cityPopulation{get;set;}

    public City(string cityName,string countyCode, int cityPopulation,int cityId=0)
    {
     _cityId = cityId;
     _countyCode=countyCode;
    _cityName = cityName;
    _cityPopulation = cityPopulation;
    }

    public static List<City> GetAllCity()
    {
        List<City> allCities=new List<City> {};
        MySqlConnection conn =DB.Connection();
        conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM city ;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
              int cityId = rdr.GetInt32(0);
              string cityName = rdr.GetString(1);
              string countyCode=rdr.GetString(2);
              int cityPopulation = rdr.GetInt32(4);
             
              City newCity = new City(cityName,countyCode,cityPopulation,cityId);
              allCities.Add(newCity);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCities;

    }

        public static List<City> GetAllCityByPopulation(string order)
        {
        List<City> allCities=new List<City> {};
        MySqlConnection conn =DB.Connection();
        conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT*FROM city ORDER BY population "+order+";";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
              int cityId = rdr.GetInt32(0);
              string cityName = rdr.GetString(1);
              string countyCode=rdr.GetString(2);
              int cityPopulation = rdr.GetInt32(4);
             
              City newCity = new City(cityName,countyCode,cityPopulation,cityId);
              allCities.Add(newCity);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCities;

    }
  }

  public class Country
  {
      public string _countryCode {get; set;}
      public string _countryName {get; set;}
      public float _lifeExpectancy {get; set;}

      public Country(string countryCode, string countryName)
      {
          _countryCode = countryCode;
          _countryName = countryName;
         // _lifeExpectancy = lifeExpectancy;
      }
      public static List<Country> GetAllCountry()
      {
          List<Country> allCountries = new List<Country> {};
          MySqlConnection conn = DB.Connection();
          conn.Open();
          MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM country;";
          MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
          while(rdr.Read())
          {
              string countryCode = rdr.GetString(0);
              string countryName = rdr.GetString(1);
              //float lifeExpectancy = rdr.GetFloat(7);
              Country newCountry = new Country(countryCode,countryName);
              allCountries.Add(newCountry);
          }
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return allCountries;
      }
      public static List<Country> GetCountrySortedBy(string sortedby, string letter)
      {
          List<Country> allCountries = new List<Country> {};
          MySqlConnection conn = DB.Connection();
          conn.Open();
          MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM country WHERE "+sortedby+" LIKE '"+letter+"%';";
          MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
          while(rdr.Read())
          {
              string countryCode = rdr.GetString(0);
              string countryName = rdr.GetString(1);
              //float lifeExpectancy = rdr.GetFloat(7);
              Country newCountry = new Country(countryCode,countryName);
              allCountries.Add(newCountry);
          }
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return allCountries;
      }
   }

 
}
  