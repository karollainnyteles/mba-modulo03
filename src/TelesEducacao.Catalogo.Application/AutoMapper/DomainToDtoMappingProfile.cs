using AutoMapper;
using TelesEducacao.Catalogo.Application.Dtos;
using TelesEducacao.Catalogo.Domain;

namespace TelesEducacao.Catalogo.Application.AutoMapper;

public class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        // CreateMap<Source, Destination>();
        CreateMap<Curso, CursoDto>();
        CreateMap<Aula, AulaDto>();
    }
}