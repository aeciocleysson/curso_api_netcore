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
  public class BaseRepository<TModel> : IRepository<TModel> where TModel : BaseEntity
  {
    // variavel de somente leitura
    protected readonly MyContext _context;
    private DbSet<TModel> _dataSet;

    public BaseRepository(MyContext context)
    {
      _context = context;

      /// <summary>
      // variavel usada como atralho para o dataset
      /// </summary>
      _dataSet = _context.Set<TModel>();
    }

    public async Task<TModel> InsertAsync(TModel item)
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

    public async Task<TModel> SelectAsync(Guid id)
    {
      try
      {
        return await _dataSet.SingleOrDefaultAsync(w => w.Id == id);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<IEnumerable<TModel>> SelectAsync()
    {
      try
      {
        return await _dataSet.ToListAsync();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<TModel> UpdatetAsync(TModel item)
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

    public async Task<bool> ExistAsync(Guid id) => await _dataSet.AnyAsync(w => w.Id == id);
  }
}
