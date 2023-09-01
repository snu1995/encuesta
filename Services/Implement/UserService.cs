using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using encuesta.Models;
using encuesta.Services.Implement;

namespace encuensta.Services.Implement
{
    public class UserService : IUserService
    {
        private readonly DbUsuarioContext _dbContext;
        public UserService(DbUsuarioContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> GetUser(string CorreoUsuario, string ClaveUsuario)
        {
            Usuario user_searcher = await _dbContext.Users.Where(u => u.CorreoUsuario == CorreoUsuario && u.ClaveUsuario == ClaveUsuario)
                 .FirstOrDefaultAsync();

            return user_searcher;
        }

        public async Task<Usuario> SaveUser(Usuario modelo)
        {
            _dbContext.Users.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
    }
}

