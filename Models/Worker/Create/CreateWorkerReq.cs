using System.ComponentModel.DataAnnotations;

namespace ServicioClienteAPI.Models.Worker.Create;

public class CreateWorkerReq
{
  [Required(ErrorMessage = "Add an Id")]
  [Range(0,int.MaxValue, ErrorMessage = "Id must be an integer and greater than 0")]
  public int Id { get; set; }
  [Required(ErrorMessage = "Name is required")]
  public required string Name { get; set; }
  [Required(ErrorMessage = "Ocupation is required")]
  public required string Ocupation { get; set; }
}
