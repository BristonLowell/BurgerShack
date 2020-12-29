using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Repositories
{
  public class ListingRepository
  {
    private readonly IDbConnection _db;

    public ListingRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Listing> GetAll()
    {
      string sql = "SELECT * FROM listings";
      return _db.Query<Listing>(sql);
    }

    public Listing Create(Listing newListing)
    {
      string sql = @"INSERT INTO listings
      (title, description, img)
      VALUES
      (@Title, @Description, @Img);
      SELECT LAST_INSERT_ID();";
      newListing.Id = _db.ExecuteScalar<int>(sql, newListing);
      return newListing;
    }

    public Listing GetById(int id)
    {
      string sql = "SELECT * FROM listings WHERE id = @Id";
      return _db.QueryFirstOrDefault<Listing>(sql, new { id });
    }

    public bool Delete(int id)
    {
      string sql = "DELETE FROM listings WHERE id = @Id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows > 0;
    }

    public Listing Edit(int id, Listing editedListing)
    {
      string sql = @"UPDATE listings SET name = @Name, meat = @Meat, buns = @Buns, sauce = @sauce WHERE id = @Id;
      SELECT * FROM burger WHERE id = @Id";
      return _db.QueryFirstOrDefault<Listing>(sql, new { id });
    }
  }
}