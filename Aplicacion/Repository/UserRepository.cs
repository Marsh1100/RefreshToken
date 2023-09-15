using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class UserRepository : GenericRepository<User>, IUser
{
    private readonly RefreshTokenContext _context;

    public UserRepository(RefreshTokenContext context) : base(context)
    {
        this._context = context;
    }

    public async Task<User> GetByRefreshToken(string refreshToken)
    {
            return await _context.Users
            .Include(u => u.Rols)
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));
    }

    public async Task<User> GetByUsernameAsync(string username)
    {
       return await _context.Users 
                .Include(u => u.Rols)
                .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower()); 
    }

    public async Task<User> GetByUserIdAsync(int id)
    {
        return await _context.Users
                .Include(u => u.Rols)
                .FirstOrDefaultAsync(u => u.Id == id);
    }
   
}
