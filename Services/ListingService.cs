using System;
using System.Collections.Generic;
using System.Reflection;
using BurgerShack.Models;
using BurgerShack.Repositories;

namespace BurgerShack.Services
{
  public class ListingService
  {
    private readonly ListingRepository _br;

    public ListingService(ListingRepository br)
    {
      _br = br;
    }
    public IEnumerable<Listing> GetAll()
    {
      return _br.GetAll();
    }

    public Listing GetById(int id)
    {
      return _br.GetById(id);
    }

    public Listing Create(Listing newListing)
    {
      return _br.Create(newListing);
    }

    public string Delete(int id)
    {
      string Deleted = "Listing Deleted";
      bool deletedListing = _br.Delete(id);
      if (deletedListing)
      {
        return Deleted;
      };
      throw new Exception("Not a valid Listing");

    }

    public Listing Edit(int id, Listing editedListing)
    {
      Listing oldListing = _br.GetById(id);


      //NOTE looping through an object and compares

      if (editedListing.Name != null)
      {
        oldListing.Name = editedListing.Name;
      }
      if (editedListing.Meat != null)
      {
        oldListing.Meat = editedListing.Meat;
      }
      if (editedListing.Buns != null)
      {
        oldListing.Buns = editedListing.Buns;
      }
      if (editedListing.Sauce != null)
      {
        oldListing.Sauce = editedListing.Sauce;
      }

      // foreach (PropertyInfo prop in oldListing.GetType().GetProperties())
      // {
      //   object oldValue = prop.GetValue(oldListing, null);
      //   object newValue = prop.GetValue(editedListing, null);
      //   if (!object.Equals(oldValue, newValue) && newValue != null)
      //   {
      //     oldValue = newValue;
      //     prop.SetValue(oldListing, newValue);
      //   }
      // }
      // oldListing = editedListing;

      return _br.Edit(id, oldListing);
    }
  }
}