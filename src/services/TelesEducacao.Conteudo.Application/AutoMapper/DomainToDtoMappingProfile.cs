using AutoMapper;
using TelesEducacao.Conteudos.Application.Dtos;
using TelesEducacao.Conteudos.Domain;

namespace TelesEducacao.Conteudos.Application.AutoMapper;

public class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        // CreateMap<Source, Destination>();
        CreateMap<Curso, CursoDto>();
        CreateMap<ConteudoProgramatico, ConteudoProgramaticoDto>();
        CreateMap<Aula, AulaDto>();
    }
}