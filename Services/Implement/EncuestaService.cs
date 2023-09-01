using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using encuesta.Models;
using encuesta.Services.Implement;
using System.Collections;

namespace encuensta.Services.Implement
{
    public class EncuestaService : IEncuestaService
    {
        private readonly DbEncuestaContext _dbContext;
        private readonly ICampoService _campoService;
        private readonly IRespuestaService _respuestaService;

        public EncuestaService(DbEncuestaContext dbContext, ICampoService campoService, IRespuestaService respuestaService)
        {
            _dbContext = dbContext;
            _campoService = campoService;
            _respuestaService = respuestaService;
        }


        public async Task<List<Encuesta>> GetListEncuesta()
        {
            List<Encuesta> encuestas = await _dbContext.EncuestaEntity.OrderBy(e => e.Id).ToListAsync();
            return encuestas;
        }

        public async Task<Encuesta> GetEncuestaById(int id)
        {
            var encuesta = await _dbContext.EncuestaEntity.FindAsync(id);

            return encuesta;
        }

        public async Task<EncuestaDTO> GetEncuestaDTOById(int id)
        {
            var encuesta = await GetEncuestaById(id);
            var campos = await _campoService.GetListCampo(id);
            var respuestas = await _respuestaService.GetListRespuesta(id);
            EncuestaDTO entity_found = new()
            {
                Descripcion = encuesta.Descripcion,
                Nombre = encuesta.Nombre,
                Enlace = encuesta.Enlace,
                Campos = campos,
                Id = encuesta.Id,
                Respuestas = respuestas.Count > 0 ? respuestas: null
            };

            return entity_found;
        }

        public async Task<EncuestaDTO> GetEncuestaDTOByIdNewResponse(int id)
        {
            var encuesta = await GetEncuestaById(id);
            var campos = await _campoService.GetListCampo(id);
            EncuestaDTO entity_found = new()
            {
                Descripcion = encuesta.Descripcion,
                Nombre = encuesta.Nombre,
                Enlace = encuesta.Enlace,
                Campos = campos,
                Id = encuesta.Id,
                Respuestas = null
            };

            return entity_found;
        }

        public async Task<Encuesta> SaveEncuesta(Encuesta modelo)
        {
            // Verificar si ya existe una encuesta con el mismo nombre
            if (await _dbContext.EncuestaEntity.AnyAsync(e => e.Nombre == modelo.Nombre))
            {
                throw new InvalidOperationException("Ya existe una encuesta con el mismo nombre.");
            }

            _dbContext.EncuestaEntity.Add(modelo);

            await _dbContext.SaveChangesAsync();

            return modelo;
        }


        public async Task<Encuesta> UpdateEncuesta(Encuesta modelo)
        {
            _dbContext.Entry(modelo).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
        public async Task<bool> DeleteEncuesta(int id)
        {
            var encuesta = await _dbContext.EncuestaEntity.FindAsync(id);

            if (encuesta == null)
            {
                return false; // No se encontró la encuesta con el ID dado
            }

            // Eliminar los campos asociados a la encuesta
            var campos = await _campoService.GetListCampo(id);
            foreach (var campo in campos)
            {
                await _campoService.DeleteCampo(campo.Id);
            }

            _dbContext.EncuestaEntity.Remove(encuesta);
            await _dbContext.SaveChangesAsync();
            return true; // Encuesta eliminada exitosamente
        }

        public async Task<ResponseEncuesta> SaveRespuesta(ResponseEncuesta modelo)
        {

            await _respuestaService.SaveRespuesta(modelo);

            return modelo;

        }

    }
}
