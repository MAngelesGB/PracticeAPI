using System.ComponentModel.DataAnnotations;

namespace ServicioClienteAPI.Models.Worker.Update;

public class UpdateWorkerReq
{
  [Required(ErrorMessage = "Name is required")]
  public string Name { get; set; }
  public string Ocupation { get; set; }
}
