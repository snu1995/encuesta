
namespace encuesta.Models;

public class ResponseEncuesta
{
    public int Id { get; set; }
    public string NombrePersona { get; set; }
    public string Valor { get; set; }
    public int EncuestaId { get; set; }
    public int CampoId { get; set; }

}