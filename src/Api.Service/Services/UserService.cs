using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using src.Api.Domain.Entities;
using src.Api.Domain.Interfaces;
using src.Api.Domain.Services.User;

namespace src.Api.Service.Services
{
  public class UserService : IUserService
  {
    private IRepository<UserEntity> _repository;

    public UserService(IRepository<UserEntity> repository)
    {
      _repository = repository;
    }

    public async Task<UserEntity> Get(Guid id) => await _repository.SelectAsync(id);
    public async Task<IEnumerable<UserEntity>> Getall() => await _repository.SelectAsync();
    public async Task<UserEntity> Post(UserEntity user) => await _repository.InsertAsync(user);
    public async Task<UserEntity> Put(UserEntity user) => await _repository.UpdatetAsync(user);
    public async Task<bool> Delete(Guid id) => await _repository.DeleteAsync(id);
  }
}
