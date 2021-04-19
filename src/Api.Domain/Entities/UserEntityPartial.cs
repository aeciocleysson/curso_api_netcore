namespace src.Api.Domain.Entities
{
  /// <summary>
  /// Exemplo de classe partial
  /// é uma parte da classe UserEntity, e todos os atributos dessa classe fazem parte da UserEntity
  /// </summary>
  public partial class UserEntity
  {
    public string Cpf { get; set; }
    public string EnderecoRuaAvenida { get; set; }
    public string EnderecoNumero { get; set; }
    public string EnderecoBairro { get; set; }
    public string EnderecoCidade { get; set; }
    public string EnderecoEstado { get; set; }
    public string EnderecoReferencia { get; set; }
  }
}
