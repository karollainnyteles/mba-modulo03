using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelesEducacao.Core.DomainObjects;

public class PagamentoMatricula
{
    public Guid AlunoId { get; private set; }
    public Guid CursoId { get; private set; }
    public string NomeCartao { get; private set; }
    public string NumeroCartao { get; private set; }
    public string ExpiracaoCartao { get; private set; }
    public string CvvCartao { get; private set; }
}