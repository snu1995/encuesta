using Microsoft.EntityFrameworkCore;

using encuesta.Models;

namespace encuesta.Services.Implement
{
    public interface IRespuestaService
    {
        Task<List<ResponseEncuesta>> GetListRespuesta(int enucuestaId);
        Task<ResponseEncuesta> GetRespuestaById(int id);
        Task<ResponseEncuesta> SaveRespuesta(ResponseEncuesta modelo);

    }
}