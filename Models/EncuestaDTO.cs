
namespace encuesta.Models;

public class EncuestaDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Enlace { get; set; }
    public List<Campo> Campos { get; set; }
    public List<ResponseEncuesta> Respuestas { get; set; }

}