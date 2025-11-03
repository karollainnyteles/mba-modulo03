using System.ComponentModel.DataAnnotations;

namespace TelesEducacao.Conteudos.Application.Dtos;

public class CursoDto
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Descricao { get; set; }

    public bool Ativo { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public decimal Valor { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Imagem { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public TimeSpan CargaHoraria { get; set; }

    public ConteudoProgramaticoDto ConteudoProgramatico { get; set; }
    public List<AulaDto> Aulas { get; set; } = new();
}