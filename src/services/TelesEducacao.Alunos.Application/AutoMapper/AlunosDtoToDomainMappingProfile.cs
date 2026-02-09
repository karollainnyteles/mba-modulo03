using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelesEducacao.Alunos.Application.Queries.Dtos;
using TelesEducacao.Alunos.Domain;

namespace TelesEducacao.Alunos.Application.AutoMapper
{
    public class AlunosDtoToDomainMappingProfile : Profile
    {
        public AlunosDtoToDomainMappingProfile()
        {
            // CreateMap<Source, Destination>();
            //CreateMap<AlunoDto, Aluno>()
            //    .ConstructUsing(c => new Aluno(c.Nome, c.Descricao, c.Ativo, c.Valor,
            //        new ConteudoProgramatico(c.ConteudoProgramatico.Titulo, c.ConteudoProgramatico.Descricao)))
            //    .ForMember(dest => dest.ConteudoProgramatico, opt => opt.Ignore());
        }
    }
}