using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace src.Api.Data.Context
{
  /// <summary>
  /// Essa classe serve para que possamos criar bancos de dados tudo em tempo de designer, 
  /// vai prover a conexão com o banco de dados para que possamos criar nossas tabelas
  /// </summary>
  public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
  {
    public MyContext CreateDbContext(string[] args)
    {
      // Usado para criar as Migrações
      var connectionString = "Host=localhost;Database=DbAPI;Username=postgres;Password=3103;Timeout=300";
      var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
      optionsBuilder.UseNpgsql(connectionString);

      return new MyContext(optionsBuilder.Options);
    }
  }
}
