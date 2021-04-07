using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Api.Data.Context;
using src.Api.Domain.Entities;
using src.Api.Domain.Interfaces;

namespace src.Api.Data.Repository
{
  /// <summary>
  /// Repository base que servira para quelquer entidade que persistira no banco
  /// </summary>
  public class BaseRepository<T> : IRepository<T> where T : BaseEntity
  {
    // variavel de somente leitura
    protected readonly MyContext _context;
    private DbSet<T> _dataSet;

    public BaseRepository(MyContext context)
    {
      _context = context;

      /// <summary>
      // variavel usada como atralho para o dataset
      /// </summary>
      _dataSet = _context.Set<T>();
    }

    public async Task<T> InsertAsync(T item)
    {
      try
      {
        if (item.Id == Guid.Empty)
        {
          item.Id = Guid.NewGuid();
        }

        item.CreatAt = DateTime.UtcNow;
        _dataSet.Add(item);
        await _context.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        throw ex;
      }

      return item;
    }

    public async Task<T> UpdatetAsync(T item)
    {
      try
      {
        var result = await _dataSet.SingleOrDefaultAsync(w => w.Id == item.Id);

        if (result == null)
          return null;

        item.UpdateAt = DateTime.UtcNow;
        item.CreatAt = result.CreatAt;

        _context.Entry(result).CurrentValues.SetValues(item);
        await _context.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        throw ex;
      }

      return item;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
      try
      {
        var result = await _dataSet.SingleOrDefaultAsync(w => w.Id == id);

        if (result == null)
          return false;

        _dataSet.Remove(result);
        await _context.SaveChangesAsync();

        return true;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public Task<T> SelectAsync(Guid id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> SelectAsync()
    {
      throw new NotImplementedException();
    }
  }
}
