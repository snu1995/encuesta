
namespace encuesta.Models;

public class ResponseEncuestaDTO
{
    public int Id { get; set; }
    public string NombrePersona { get; set; }
    public string Valor { get; set; }
    public int EncuestaId { get; set; }
    public int CampoId { get; set; }
    public string CampoTitulo { get; set; }
    public string CampoNombre { get; set; }

}