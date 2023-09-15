using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Entitites;
using Microsoft.EntityFrameworkCore;

namespace Persistencia;

public class RefreshTokenContext : DbContext
{
    public RefreshTokenContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Rol> Roles { get; set; }
    public DbSet<User> Users{ get; set; }
    public DbSet<UserRol> UsersRols { get; set; }

    public DbSet<RefreshToken> RefreshTokens{ get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }   
}
