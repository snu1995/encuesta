using Microsoft.EntityFrameworkCore;

using encuesta.Models;

namespace encuesta.Services.Implement
{
    public interface ICampoService
    {
        Task<List<Campo>> GetListCampo(int id);
        Task<Campo> GetCampoById(int id);
        Task<Campo> SaveCampo(Campo modelo);
        Task<Campo> UpdateCampo(Campo modelo);
        Task<bool> DeleteCampo(int id);

    }
}