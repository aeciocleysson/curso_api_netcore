namespace src.Api.Domain.Entities
{
  public partial class UserEntity
  {
    public string Cpf { get; set; }
    public string EnderecoRuaAvenida { get; set; }
    public string EnderecoNumero { get; set; }
    public string EnderecoBairro { get; set; }
    public string EnderecoCidade { get; set; }
    public string EnderecoEstado { get; set; }
  }
}
