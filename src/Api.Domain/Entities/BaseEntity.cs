using System;
using System.ComponentModel.DataAnnotations;

namespace src.Api.Domain.Entities
{
  /// <summary>
  /// Classe base de entidades (BaseModel no projeto BH)
  /// </summary>
  public abstract class BaseEntity
  {
    [Key]
    public Guid Id { get; set; }

    private DateTime? _creatAt;

    public DateTime? CreatAt
    {
      /// <summary>
      /// retorna o valor da propriedade interna
      /// </summary>
      get { return _creatAt; }

      /// <summary>
      /// se o valor chgar nulo, vai receber o valor de Datetime.UtcNow que é o valor da data padrão no servidor
      /// caso não venha nulo ira receber o valor que vier passado pelo parâmetro
      /// </summary>
      set { _creatAt = value == null ? DateTime.UtcNow : value; }

    }

    public DateTime? UpdateAt { get; set; }

  }
}
