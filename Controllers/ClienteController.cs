using Microsoft.AspNetCore.Mvc;
using ServicioClienteAPI.Models.Client.Create;
using ServicioClienteAPI.Models.Client.Update;


namespace ServicioClienteAPI;
//Atributo para definir que es un controlador de API
[ApiController]
//Atributo para definir la ruta de acceso
[Route("api/[controller]")]

public class ClienteController : ControllerBase
{
  //Atributo para definir la ruta de acceso
  [HttpGet]
  public ActionResult Get()
  {
    return Ok("Hola Mundo");
  }

  [HttpGet("Get2")]
  public ActionResult Get2()
  {
    return Ok("Hola Mundo2");
  }

  [HttpGet("{id}")]
  public ActionResult Get(int id)
  {
    if (id < 1)
    {
      return BadRequest("El id no puede ser menor a 1");
    }
    if (id == 5){
      return NotFound("El id 5 no existe");
    }
    return Ok($"Hola Mundo {id}");
  }

  [HttpPost]
  public ActionResult Post ([FromBody] CreateClientRequest request){
    if (request.Age < 18){
      return BadRequest("You're not an adult");
    }
    return Ok($"your name {request.Name} and your age is {request.Age}");
  }

  [HttpDelete ("{id}")]
  public ActionResult Delete (int id){
    if (id < 0) {
      return BadRequest("id incorrect");
    }
    return Ok("Item deleted successful"); 
  }

  [HttpPut ("{id}")]
  public ActionResult Put (int id, [FromBody] UpdateClientReq req){
    if(id < 0)
    {
      return NotFound("Id do not exist");
    }
    if(req.Name.Length != 0 && req.Age != 0 && req.LastName != string.Empty){
      return Ok("Item updated successful");
    }
    else{
      return BadRequest("Items empty"); 
    }
    
  }

}