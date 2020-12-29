using BurgerShack.Models;
using BurgerShack.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BurgerShack.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class ListingController : ControllerBase
  {
    private readonly ListingService _bs;

    public ListingController(ListingService bs)
    {
      _bs = bs;
    }


    [HttpGet]

    public ActionResult<IEnumerable<Listing>> GetAll()
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

    public ActionResult<Listing> GetById(int id)
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

    public ActionResult<Listing> Create([FromBody] Listing newListing)
    {
      try
      {
        return Ok(_bs.Create(newListing));
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

    public ActionResult<Listing> Edit(int id, [FromBody] Listing editedListing)
    {
      try
      {
        return Ok(_bs.Edit(id, editedListing));
      }
      catch (System.Exception err)
      {

        return BadRequest(err);
      }
    }


  }
}