using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using src.Api.Domain.Entities;

namespace src.Api.Domain.Interfaces
{
  /// <summary>
  /// Interface genérica do tipo T, que sera injetado no tipo T alguma classe que tenha herança de BaseEntity
  /// </summary>
  public interface IRepository<TModel> where TModel : BaseEntity
  {
    Task<TModel> InsertAsync(TModel item);
    Task<TModel> SelectAsync(Guid id);
    Task<IEnumerable<TModel>> SelectAsync();
    Task<TModel> UpdatetAsync(TModel item);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> ExistAsync(Guid id);
  }
}
