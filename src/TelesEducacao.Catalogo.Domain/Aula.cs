﻿using TelesEducacao.Core.DomainObjects;

namespace TelesEducacao.Catalogo.Domain;

public class Aula : Entity
{
    public string Titulo { get; set; }
    public string Conteudo { get; set; }
    public TimeSpan Duracao { get; set; }

    public List<string> MaterialApoio { get; private set; } = new();
    public Guid CursoId { get; set; }

    public Curso Curso { get; set; }

    public Aula(string titulo, string conteudo, TimeSpan duracao, Guid cursoId)
    {
        Titulo = titulo;
        Conteudo = conteudo;
        Duracao = duracao;
        CursoId = cursoId;

        Validar();
    }

    public void AdicionarMaterialApoio(string material)
    {
        MaterialApoio.Add(material);
    }

    public void AlterarTitulo(string titulo)
    {
        Titulo = titulo;
        Validacoes.ValidarSeVazio(Titulo, "O campo Titulo da aula não pode estar vazio");
    }

    public void AlterarConteudo(string conteudo)
    {
        Conteudo = conteudo;
        Validacoes.ValidarSeVazio(Conteudo, "O campo Conteudo da aula não pode estar vazio");
    }

    public void Validar()
    {
        Validacoes.ValidarSeIgual(CursoId, Guid.Empty, "O campo CursoId da aula não pode estar vazio");
        Validacoes.ValidarSeVazio(Titulo, "O campo Titulo da aula não pode estar vazio");
        Validacoes.ValidarSeVazio(Conteudo, "O campo Conteudo da aula não pode estar vazio");
        Validacoes.ValidarSeMenorQue(Duracao, TimeSpan.FromMinutes(1), "O campo Duracao da aula não pode ser menor que 1 minuto");
    }
}