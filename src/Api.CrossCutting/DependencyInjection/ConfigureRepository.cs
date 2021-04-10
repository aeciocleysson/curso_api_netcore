using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using src.Api.Data.Context;
using src.Api.Data.Repository;
using src.Api.Domain.Interfaces;

namespace Api.CrossCutting.DependencyInjection
{
  public static class ConfigureRepository
  {
    public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
    {
      serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

      serviceCollection.AddDbContext<MyContext>(options =>
       options.UseNpgsql("Host=localhost;Database=dbAPI;Username=postgres;Password=3103"));
    }
  }
}