using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using encuesta.Models;
using encuesta.Services.Implement;

namespace encuensta.Services.Implement
{
    public class RespuestaService : IRespuestaService
    {
        private readonly DbRespuestaContext _dbContext;
        public RespuestaService(DbRespuestaContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<ResponseEncuesta>> GetListRespuesta(int encuestaId)
        {

            List<ResponseEncuesta> respuestas = await _dbContext.RespuestaEntity
                .Where(c => c.EncuestaId == encuestaId)
                .OrderBy(e => e.Id)
                .ToListAsync();

            return respuestas;
        }

        public async Task<ResponseEncuesta> GetRespuestaById(int id)
        {
            var respuesta = await _dbContext.RespuestaEntity.FindAsync(id);
            return respuesta;
        }

        public async Task<ResponseEncuesta> SaveRespuesta(ResponseEncuesta modelo)
        {
            _dbContext.RespuestaEntity.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }

    }
}


