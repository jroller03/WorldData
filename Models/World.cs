using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldData;
using System;

namespace WorldData.Models
{
  public class Country
  {
    private string _code;
    private string _name;
    private string _continent;
    private string _governmentForm;
    private string _headOfState;
    // private string _capital;

    public Country(string Code, string Name, string Continent, string GovernmentForm, string HeadOfState /*string Capital*/)
    {
      _code = Code;
      _name = Name;
      _continent = Continent;
      _governmentForm = GovernmentForm;
      _headOfState = HeadOfState;
      // _capital = Capital;
    }
    public string GetCode()
    {
      return _code;
    }
    public void SetCode(string newCode)
    {
      _code = newCode;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    public string GetContinent()
    {
      return _continent;
    }
    public void SetContinent(string newContinent)
    {
      _continent = newContinent;
    }
    public string GetGovernmentForm()
    {
      return _governmentForm;
    }
    public void SetGovernmentForm(string newGovernmentForm)
    {
      _governmentForm = newGovernmentForm;
    }
    public string GetHeadOfState()
    {
      return _headOfState;
    }
    public void SetHeadOfState(string newHeadOfState)
    {
      _headOfState = newHeadOfState;
    }
    // public string GetCapital()
    // {
    //   return _capital;
    // }
    // public void SetCapital(string newCapital)
    // {
    //   _capital = newCapital;
    // }

    public static List<Country> GetAll()
    {
      List<Country> allCountries = new List<Country> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string countryCode = rdr.GetString(0);
        string countryName = rdr.GetString(1);
        string countryContinent = rdr.GetString(2);
        string countryGovernment = rdr.GetString(11);
        string countryHeadOfState = "INITIAL";
        try
        {
          countryHeadOfState = rdr.GetString(12);
        } catch {
          countryHeadOfState = "none";
        }
        // string countryCapital = rdr.GetString(13);
        Country newCountry = new Country(countryCode, countryName, countryContinent, countryGovernment, countryHeadOfState /*countryCapital*/);
        allCountries.Add(newCountry);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCountries;
    }
    public static List<Country> GetByContinent(string inputValue)
    {
      List<Country> allCountries = new List<Country> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country WHERE continent LIKE '" + inputValue + "%\';";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string countryCode = rdr.GetString(0);
        string countryName = rdr.GetString(1);
        string countryContinent = rdr.GetString(2);
        string countryGovernment = rdr.GetString(11);
        string countryHeadOfState = "INITIAL";
        try
        {
          countryHeadOfState = rdr.GetString(12);
        } catch {
          countryHeadOfState = "none";
        }
        // string countryCapital = rdr.GetString(13);
        Country newCountry = new Country(countryCode, countryName, countryContinent, countryGovernment, countryHeadOfState /*countryCapital*/);
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
