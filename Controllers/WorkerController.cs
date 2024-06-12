using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using ServicioClienteAPI.Models;
using ServicioClienteAPI.Models.Worker.Create;
using ServicioClienteAPI.Models.Worker.Update; 
namespace ServicioClienteAPI.Controllers;

//Attribute to specifie that is an API Controller
[ApiController]
//Attribute to specified access route
[Route("api/[Controller]")]

public class WorkerController:ControllerBase
{
  //Clase List y entre <> el tipo de dato de la lista seguido del nombre
  List<DataWorker> dataWorker=[
    new DataWorker{Id = 1, Name = "Cassandra", Ocupation = "DBA"},
    new DataWorker{Id = 2, Name = "Lissandro", Ocupation = "BackEnd Programmer"}, 
    new DataWorker{Id = 3, Name = "Julian", Ocupation = "FrontEnd Programmar"}, 
    new DataWorker{Id = 4, Name = "Margara", Ocupation = "PM"}, 
  ];


  [HttpGet("ListItems")]
  public ActionResult Get(){
    if (dataWorker is null)
      return NotFound("Items not exist"); 
    return Ok(dataWorker); 
  }

  [HttpGet("ObtainWorker/{id}")]

  public ActionResult Get(int id){
    DataWorker? worker = dataWorker.FirstOrDefault(x=> x.Id == id); 
    
    if (worker is null)
      return NotFound("Item not found"); 
    return Ok(worker); 
  }

  [HttpPost("AddWorker")]
  public ActionResult Post([FromBody] CreateWorkerReq req){
    if(!ModelState.IsValid)
    {
      return BadRequest(ModelState); 
    }
    else
    {
      DataWorker worker = new DataWorker(); 
      worker.Id = req.Id; 
      worker.Name = req.Name; 
      worker.Ocupation = req.Ocupation; 
      dataWorker.Add(worker); 
      return Ok($"User {req.Name} added"); 
    }
  }

  // ------- Methods to Uptade workers ------

  private DataWorker? obtainDataWorker(int id){
    DataWorker? worker = dataWorker.FirstOrDefault(x=>x.Id==id); 
    return worker; 
  }

  private void workerUpdate(DataWorker worker){
    var index = dataWorker.FindIndex(x => x.Id == worker.Id); 
    if (index != -1){
      dataWorker[index] = worker; 
    }
  }
  // --------------------------------------

  [HttpPut("UpdateWorker/{id}")]
  public ActionResult Put(int id, [FromBody] UpdateWorkerReq req){
    if(!ModelState.IsValid){
      return BadRequest(ModelState); 
    }
    else{
      var workerToUpdate = obtainDataWorker(id); 
      if (workerToUpdate is null)
        return NotFound("Worker Not Found");  
      
      workerToUpdate.Name = req.Name; 
      workerToUpdate.Ocupation = req.Ocupation;

      workerUpdate(workerToUpdate);
      
      return Ok($"worker {req.Name} is update"); 
    }
  }

  [HttpDelete("DeleteWorker/{id}")]
  public ActionResult Delete(int id){
    var index = dataWorker.FindIndex(x => x.Id == id); 
    if (index != -1)
      dataWorker.RemoveAt(index); 
    else
      return NotFound("worker not found"); 
    return Ok("Worker is delete");
  }
}