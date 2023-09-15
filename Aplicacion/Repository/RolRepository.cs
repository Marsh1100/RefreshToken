using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;

public class RolRepository : GenericRepository<Rol>, IRol
{
   private readonly RefreshTokenContext _context;

   public RolRepository(RefreshTokenContext context) : base(context)
   {
        this._context = context;    
   } 

   
}
