using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Api.Domain.Services.User;

namespace Api.Application.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    [HttpGet]
    public async Task<ActionResult> GetAll([FromServices] IUserService service)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      try
      {
        return Ok(await service.Getall());
      }
      catch (ArgumentException e)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
      }
    }
  }
}
