using TelesEducacao.Core.DomainObjects;

namespace TelesEducacao.Catalogo.Domain
{
    public class Curso : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public string Imagem { get; private set; }
        public TimeSpan CargaHoraria { get; set; }

        public ConteudoProgramatico ConteudoProgramatico { get; private set; }
        public List<Aula> Aulas { get; private set; } = new();

        public Curso(string nome, string descricao, bool ativo, decimal valor, string imagem, ConteudoProgramatico conteudoProgramatico)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            Imagem = imagem;
            ConteudoProgramatico = conteudoProgramatico;

            Validar();
        }

        //ad hoc setters
        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;

        public void AlterarNome(string nome)
        {
            Nome = nome;
            Validacoes.ValidarSeVazio(Nome, "O campo Nome do curso não pode estar vazio");
        }

        public void AlterarDescricao(string descricao)
        {
            Descricao = descricao;
            Validacoes.ValidarSeVazio(Descricao, "O campo Descricao do curso não pode estar vazio");
        }

        public void AlterarValor(decimal valor)
        {
            Valor = valor;
            Validacoes.ValidarSeMenorQue(Valor, 1, "O campo Valor do curso não pode se menor igual a 0");
        }

        public void AlterarImagem(string imagem)
        {
            Imagem = imagem;
            Validacoes.ValidarSeVazio(Imagem, "O campo Imagem do curso não pode estar vazio");
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome do curso não pode estar vazio");
            Validacoes.ValidarSeVazio(Descricao, "O campo Descricao do curso não pode estar vazio");
            Validacoes.ValidarSeMenorQue(Valor, 1, "O campo Valor do curso não pode se menor igual a 0");
            Validacoes.ValidarSeVazio(Imagem, "O campo Imagem do curso não pode estar vazio");
        }
    }
}