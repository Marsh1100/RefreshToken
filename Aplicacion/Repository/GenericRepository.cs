using Dominio.Interfaces;
using Dominio.Entities;
using Persistencia;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
namespace Aplicacion.Repository;


public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly RefreshTokenContext _context;

    public GenericRepository(RefreshTokenContext context)
    {
        _context = context;
    }

    public virtual void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public virtual void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }

    public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

   
   /*public Task<(int totalRecord, IEnumerable<T> records)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        throw new NotImplementedException();
    }*/

    public virtual async Task<(int totalRegistros, IEnumerable<T> registros)>GetAllAsync(int pageIndex, int pageSize, string _search)
    {
        var totalRegistros =  await _context.Set<T>().CountAsync();
        var registros = await _context.Set<T>()
            .Skip((pageIndex -1)* pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public virtual async Task<T> GetByIdAsync(string id)
    {
        return await _context.Set<T>().FindAsync(id);
    }


    public virtual void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }

    public virtual void Update(T entity)
    {
        _context.Set<T>()
            .Update(entity);
    }
}