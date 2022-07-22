using AutoMapper;
using MyTarefas.Application.Dtos;
using MyTarefas.Domain;

namespace MyTarefas.Application.Helpers
{
    public class MyTarefasProfile : Profile
    {
        public MyTarefasProfile()
        {                           
            CreateMap<Card, CardDto>().ReverseMap();
            CreateMap<Departamento, DepartamentoDto>().ReverseMap();
            CreateMap<Tarefa, TarefaDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Acompanhamento, AcompanhamentoDto>()
                 .ForMember(dto => dto.Usuarios, opt => opt.MapFrom(x => x.AcompanhamentosUsuarios.Select(y => y.Usuario).ToList())).ReverseMap();

        }
    }
}