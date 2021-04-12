using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using src.Api.Domain.Entities;

namespace src.Api.Domain.Interfaces
{
  /// <summary>
  /// Interface genérica do tipo T, que sera injetado no tipo T alguma classe que tenha herança de BaseEntity
  /// </summary>
  public interface IRepository<T> where T : BaseEntity
  {
    Task<T> InsertAsync(T item);
    Task<T> SelectAsync(Guid id);
    Task<IEnumerable<T>> SelectAsync();
    Task<T> UpdatetAsync(T item);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> ExistAsync(Guid id);
  }
}
