using Microsoft.Extensions.DependencyInjection;
using src.Api.Domain.Services.User;
using src.Api.Service.Services;

namespace Api.CrossCutting.DependencyInjection
{
  public static class ConfigureService
  {
    public static void ConfigureDependenciesServices(IServiceCollection serviceCollection)
    {
      serviceCollection.AddScoped<IUserService, UserService>();
    }
  }
}
