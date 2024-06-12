using Microsoft.AspNetCore.Mvc;
using ServicioClienteAPI.Models;
using ServicioClienteAPI.Models.Person;
namespace ServicioClienteAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
  private List<DataPerson> persons =
  [
    new DataPerson{Id = 1, Name = "Julio"},
    new DataPerson{Id = 2, Name = "Rosa"},
    new DataPerson{Id = 3, Name = "Concepcion"}
  ];

  [HttpGet]
  public ActionResult Get()
  {
    return Ok(persons);
  }

  //Obtener un dato
  [HttpGet("{id}")]
  public ActionResult Get(int id)
  {

    DataPerson? person = persons.FirstOrDefault(x => x.Id == id);
    if (person is null)
    {
      return NotFound("Item not found");
    }
    return Ok(person);

  }

  //agregar un dato
  [HttpPost]
  public ActionResult Post([FromBody] CreatePersonReq req){
    if(req.Id > 0 && req.Name != string.Empty){
      DataPerson dataPerson = new DataPerson();
      dataPerson.Id = req.Id; 
      dataPerson.Name = req.Name; 
      persons.Add(dataPerson); 
      return Ok($"User {req.Name} registered"); 
    }
    else{
      return BadRequest("Items empty"); 
    }
  }

}
