using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Api.Domain.Entities;
using src.Api.Domain.Services.User;

namespace Api.Application.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {

    public UserController(IUserService service)
    {
      _service = service;
    }

    private IUserService _service;

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] UserEntity user)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      try
      {
        var result = await _service.Post(user);

        if (result != null)
          return Created(new Uri(Url.Link("GetWithId", new { id = result.Id })), result);
        else
          return BadRequest();
      }
      catch (ArgumentException e)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
      }
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      try
      {
        return Ok(await _service.Getall());
      }
      catch (ArgumentException e)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
      }
    }

    [HttpGet, Route("{id}", Name = "GetWithId")]
    public async Task<ActionResult> GetById(Guid id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      try
      {
        return Ok(await _service.Get(id));
      }
      catch (ArgumentException e)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
      }
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] UserEntity user)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      try
      {
        var result = await _service.Put(user);

        if (result != null)
          return Ok(result);
        else
          return BadRequest();
      }
      catch (ArgumentException e)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
      }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      try
      {
        return Ok(await _service.Delete(id));
      }
      catch (ArgumentException e)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
      }
    }
  }
}
