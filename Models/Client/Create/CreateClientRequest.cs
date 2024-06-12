namespace ServicioClienteAPI.Models.Client.Create;

public class CreateClientRequest
{
  public required string Name { get; set; }
  public int Age { get; set; }
  public required string LastName { get; set; }
}
