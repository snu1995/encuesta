
namespace encuesta.Models;

public class BuildEncuesta
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Enlace { get; set; }
    public string NombrePersona { get; set; }
    public List<ResponseEncuestaDTO> ResponseEncuesta { get; set; }

}