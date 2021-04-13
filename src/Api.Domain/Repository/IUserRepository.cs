using System.Threading.Tasks;
using src.Api.Domain.Entities;
using src.Api.Domain.Interfaces;

namespace src.Api.Domain.Repository
{
  /// <summary>
  /// Interface criada para fazer a método de ligin com autenticação com JWT
  /// </summary>
  public interface IUserRepository : IRepository<UserEntity>
  {
    Task<UserEntity> FindByLogin(string email);
  }
}
