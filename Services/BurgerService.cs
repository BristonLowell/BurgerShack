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

    // public Burger Create(Burger newBurger)
    // {
    //   // return newBurger;
    // }

    // public string Delete(int index)
    // {
    //   // return "Burger deleted!";
    // }

    // public Burger Edit(int index, Burger editedBurger)
    // {
    //   Burger oldBurger = FakeDB.burgers[index];

    //   //NOTE looping through an object and compares

    //   foreach (PropertyInfo prop in oldBurger.GetType().GetProperties())
    //   {
    //     object oldValue = prop.GetValue(oldBurger, null);
    //     object newValue = prop.GetValue(editedBurger, null);
    //     if (!object.Equals(oldValue, newValue) && newValue != null)
    //     {
    //       oldValue = newValue;
    //       prop.SetValue(oldBurger, newValue);
    //     }
    //   }
    //   FakeDB.burgers[index] = editedBurger;
    //   return editedBurger;
    // }
  }
}