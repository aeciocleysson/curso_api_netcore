using Microsoft.EntityFrameworkCore;
using src.Api.Domain.Entities;

namespace src.Api.Data.Context
{
  /// <summary>
  /// DbContext representa uma combinação dos padrões Unit-Of-Work e Repository e permite consultar um banco de dados e agrupar
  /// as alterações que serão gravadas de volta ao armazenamento como uma unidade. 
  /// O DataContext é a fonte de todas as entidades mapeados em uma conexão de banco de dados.
  /// </summary>
  public class MyContext : DbContext
  {
    public MyContext(DbContextOptions<MyContext> options) : base(options) { }

    public DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }
  }
}