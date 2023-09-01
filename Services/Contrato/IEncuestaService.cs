using Microsoft.EntityFrameworkCore;

using encuesta.Models;

namespace encuesta.Services.Implement
{
    public interface IEncuestaService
    {
        Task<List<Encuesta>> GetListEncuesta();
        Task<Encuesta> GetEncuestaById(int id);
        Task<EncuestaDTO> GetEncuestaDTOById(int id);
        Task<EncuestaDTO> GetEncuestaDTOByIdNewResponse(int id);
        Task<Encuesta> SaveEncuesta(Encuesta modelo);
        Task<Encuesta> UpdateEncuesta(Encuesta modelo);
        Task<bool> DeleteEncuesta(int id);
        Task<ResponseEncuesta> SaveRespuesta(ResponseEncuesta modelo);

    }
}