namespace ServicioClienteAPI.Models.Client.Update;

public class UpdateClientReq
{
  public required string Name { get; set; }
  public int Age { get; set; }
  public required string LastName { get; set; }
}
