using Microsoft.EntityFrameworkCore;

using encuesta.Models;

namespace encuesta.Services.Implement
{
    public interface IUserService
    {
        Task<Usuario> GetUser(string email, string password);
        Task<Usuario> SaveUser(Usuario modelo);
    }
}