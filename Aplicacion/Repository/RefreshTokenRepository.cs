using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Entitites;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;

public class RefreshTokenRepository : GenericRepository<RefreshToken>, IRefreshToken
{
   private readonly RefreshTokenContext _context;

   public RefreshTokenRepository(RefreshTokenContext context) : base(context)
   {
        this._context = context;    
   } 

   
}
