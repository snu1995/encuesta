
namespace encuesta.Models;

public class Campo
{
    
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Titulo { get; set; }
    public bool EsRequerido { get; set; }
    public int TipoCampoId { get; set; }
    public int EncuestaId { get; set; }

}