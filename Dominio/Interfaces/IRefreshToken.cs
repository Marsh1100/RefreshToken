using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Entitites;

namespace Dominio.Interfaces;

public interface IRefreshToken: IGenericRepository<RefreshToken>
{
}
