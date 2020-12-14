using System;
using System.Collections.Generic;
using System.Reflection;
using BurgerShack.Models;
using BurgerShack.Repositories;

namespace BurgerShack.Services
{
  public class BurgerService
  {
    private readonly BurgerRepository _br;

    public BurgerService(BurgerRepository br)
    {
      _br = br;
    }
    public IEnumerable<Burger> GetAll()
    {
      return _br.GetAll();
    }

    public Burger GetById(int id)
    {
      return _br.GetById(id);
    }

    public Burger Create(Burger newBurger)
    {
      return _br.Create(newBurger);
    }

    public string Delete(int id)
    {
      string Deleted = "Burger Deleted";
      bool deletedBurger = _br.Delete(id);
      if (deletedBurger)
      {
        return Deleted;
      };
      throw new Exception("Not a valid Burger");

    }

    public Burger Edit(int id, Burger editedBurger)
    {
      Burger oldBurger = _br.GetById(id);


      //NOTE looping through an object and compares

      if (editedBurger.Name != null)
      {
        oldBurger.Name = editedBurger.Name;
      }
      if (editedBurger.Meat != null)
      {
        oldBurger.Meat = editedBurger.Meat;
      }
      if (editedBurger.Buns != null)
      {
        oldBurger.Buns = editedBurger.Buns;
      }
      if (editedBurger.Sauce != null)
      {
        oldBurger.Sauce = editedBurger.Sauce;
      }

      // foreach (PropertyInfo prop in oldBurger.GetType().GetProperties())
      // {
      //   object oldValue = prop.GetValue(oldBurger, null);
      //   object newValue = prop.GetValue(editedBurger, null);
      //   if (!object.Equals(oldValue, newValue) && newValue != null)
      //   {
      //     oldValue = newValue;
      //     prop.SetValue(oldBurger, newValue);
      //   }
      // }
      // oldBurger = editedBurger;

      return _br.Edit(id, oldBurger);
    }
  }
}