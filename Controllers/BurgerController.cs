using BurgerShack.Models;
using BurgerShack.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BurgerShack.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class BurgerController : ControllerBase
  {
    private readonly BurgerService _bs;

    public BurgerController(BurgerService bs)
    {
      _bs = bs;
    }


    [HttpGet]

    public ActionResult<IEnumerable<Burger>> GetAll()
    {
      try
      {
        return Ok(_bs.GetAll());
      }
      catch (System.Exception err)
      {

        return BadRequest(err);
      }
    }

    [HttpGet("{id}")]

    public ActionResult<Burger> GetById(int id)
    {
      try
      {
        return Ok(_bs.GetById(id));
      }
      catch (System.Exception err)
      {

        return BadRequest(err);
      }
    }


    [HttpPost]

    public ActionResult<Burger> Create([FromBody] Burger newBurger)
    {
      try
      {
        return Ok(_bs.Create(newBurger));
      }
      catch (System.Exception err)
      {

        return BadRequest(err);
      }
    }

    [HttpDelete("{id}")]

    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_bs.Delete(id));
      }
      catch (System.Exception err)
      {

        return BadRequest(err);
      }
    }

    [HttpPut("{id}")]

    public ActionResult<Burger> Edit(int id, [FromBody] Burger editedBurger)
    {
      try
      {
        return Ok(_bs.Edit(id, editedBurger));
      }
      catch (System.Exception err)
      {

        return BadRequest(err);
      }
    }


  }
}