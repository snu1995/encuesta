using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using encuesta.Models;
using encuesta.Services.Implement;

namespace encuensta.Services.Implement
{
    public class CampoService : ICampoService
    {
        private readonly DbCampoContext _dbContext;
        public CampoService(DbCampoContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<Campo>> GetListCampo(int id)
        {
            List<Campo> campos = await _dbContext.CampoEntity.Where(c => c.EncuestaId == id).OrderBy(e => e.Id).ToListAsync();
            return campos;
        }

        public async Task<Campo> GetCampoById(int id)
        {
            var campo = await _dbContext.CampoEntity.FindAsync(id);
            return campo;
        }

        public async Task<Campo> SaveCampo(Campo modelo)
        {
            _dbContext.CampoEntity.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }

        public async Task<Campo> UpdateCampo(Campo modelo)
        {
            _dbContext.Entry(modelo).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
        public async Task<bool> DeleteCampo(int id)
        {
            var campo = await _dbContext.CampoEntity.FindAsync(id);

            if (campo == null)
            {
                return false; // No se encontró la encuesta con el ID dado
            }

            _dbContext.CampoEntity.Remove(campo);
            await _dbContext.SaveChangesAsync();
            return true; // Campo eliminada exitosamente
        }

  
    }
}


