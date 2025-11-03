using AutoMapper;
using TelesEducacao.Conteudos.Application.Dtos;
using TelesEducacao.Conteudos.Domain;

namespace TelesEducacao.Conteudos.Application.AutoMapper;

public class DtoToDomainMappingProfile : Profile
{
    public DtoToDomainMappingProfile()
    {
        // CreateMap<Source, Destination>();
        CreateMap<CursoDto, Curso>()
            .ConstructUsing(c => new Curso(c.Nome, c.Descricao, c.Ativo, c.Valor, c.Imagem,
                new ConteudoProgramatico(c.ConteudoProgramatico.Titulo, c.ConteudoProgramatico.Descricao)));
        CreateMap<AulaDto, Aula>()
            .ConstructUsing(a => new Aula(a.Titulo, a.Conteudo, a.Duracao, a.CursoId));
    }
}