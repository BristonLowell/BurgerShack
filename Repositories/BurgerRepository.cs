using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Repositories
{
  public class BurgerRepository
  {
    private readonly IDbConnection _db;

    public BurgerRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Burger> GetAll()
    {
      string sql = "SELECT * FROM burgers";
      return _db.Query<Burger>(sql);
    }

    public Burger Create(Burger newBurger)
    {
      string sql = @"INSERT INTO burgers
      (name, meat, buns, sauce)
      VALUES
      (@Name, @Meat, @Buns, @Sauce);
      SELECT LAST_INSERT_ID();";
      newBurger.Id = _db.ExecuteScalar<int>(sql, newBurger);
      return newBurger;
    }

    public Burger GetById(int id)
    {
      string sql = "SELECT * FROM burgers WHERE id = @Id";
      return _db.QueryFirstOrDefault<Burger>(sql, new { id });
    }

    public bool Delete(int id)
    {
      string sql = "DELETE FROM burgers WHERE id = @Id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows > 0;
    }

    public Burger Edit(int id, Burger editedBurger)
    // let sql = 'INSERT INTO leaderboard(username, data) VALUES(?, ?)';
    {
      string sql = @"UPDATE burgers SET name = @Name, meat = @Meat, buns = @Buns, sauce = @sauce WHERE id = @Id;
      SELECT * FROM burger WHERE id = @Id";
      editedBurger.Id = _db.ExecuteScalar<int>(sql, editedBurger);
      return editedBurger;

    }

    //  public bool Delete(int id)
    //     {
    //         string sql = "DELETE FROM burgers WHERE id = @Id LIMIT 1";
    //         int affectedRows = _db.Execute(sql, new { id });
    //         return affectedRows > 0;
    //     }
  }
}