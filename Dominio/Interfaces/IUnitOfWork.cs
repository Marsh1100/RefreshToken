using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interfaces;

public interface IUnitOfWork
{
    IUser Users { get; }
    IRol Roles { get; }

    IRefreshToken RefreshTokens { get; }

    Task<int> SaveAsync(); //Cuantos registros han sido aferctados en cada petición
}
