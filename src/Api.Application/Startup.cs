using Api.CrossCutting.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Application
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      ConfigureRepository.ConfigureDependenciesRepository(services);
      ConfigureService.ConfigureDependenciesServices(services);

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
              Title = "Curso de AspNetCore",
              Version = "v1",
              Description = "Exemplo de Api REST criada com o ASP.NET Core"
            });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();

        #region Configurações do Swagger

        //Ativando Middlewares para use do Swagger
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
          c.RoutePrefix = string.Empty;
          c.SwaggerEndpoint("/swagger/v1/swagger.json", "Curso de API com AspNetCore");
        });

        // Redireciona o Link para o Swagger, quando acessar a rota principal
        var option = new RewriteOptions();
        option.AddRedirect("^$", "swagger");
        app.UseRewriter(option);

        #endregion

      }

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
