using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using src.Api.Domain.Entities;

namespace src.Api.Domain.Services.User
{
  public interface IUserService
  {
    Task<UserEntity> Post(UserEntity user);
    Task<UserEntity> Get(Guid id);
    Task<IEnumerable<UserEntity>> Getall();
    Task<UserEntity> Put(UserEntity user);
    Task<bool> Delete(Guid id);
  }
}
