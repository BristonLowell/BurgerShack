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

    // [HttpPost]

    // public ActionResult<Burger> Create([FromBody] Burger newBurger)
    // {
    //   try
    //   {
    //     return Ok(_bs.Create(newBurger));
    //   }
    //   catch (System.Exception err)
    //   {

    //     return BadRequest(err);
    //   }
    // }

    // [HttpDelete("{index}")]

    // public ActionResult<string> Delete(int index)
    // {
    //   try
    //   {
    //     return Ok(_bs.Delete(index));
    //   }
    //   catch (System.Exception err)
    //   {

    //     return BadRequest(err);
    //   }
    // }

    // [HttpPut("{index}")]

    // public ActionResult<Burger> Edit(int index, [FromBody] Burger editedBurger)
    // {
    //   try
    //   {
    //     return Ok(_bs.Edit(index, editedBurger));
    //   }
    //   catch (System.Exception err)
    //   {

    //     return BadRequest(err);
    //   }
    // }


  }
}