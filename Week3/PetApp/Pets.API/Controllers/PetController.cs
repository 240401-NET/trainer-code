using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pets.Models;

namespace Pets.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{

    // If you want to return your own status code, you can use ControllerBase's methods to do so.
    // Query Parameters
    [HttpGet]
    public ActionResult<string> Greet([FromQuery] string? name) {
        if(name is not null) {
            return Ok($"Hello, {name}!");
        }
        else {
            return Ok("Hello!");
        }
    }

// Route params
    [HttpGet("{name}")]
    public ActionResult<string> SayHello([FromRoute] string name) {
        return Ok($"Hello, {name}!");
    }

// Subroutes with route params
    [HttpGet("greet/{name}")]
    public ActionResult<string> Hello(string name, int age) {
        return Ok($"Hello, {name}!");
    }

    [HttpPost] //HttpPut, HttpDelete
    public ActionResult<string> GreetPost(string name, Pet pet) {
        if(name is not null) {
            return Ok($"Hello, {name}!");
        }
        else {
            return Ok("Hello!");
        }
    }
}
