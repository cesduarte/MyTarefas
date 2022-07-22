using AutoMapper;
using MyTarefas.Application.Contratos;
using MyTarefas.Application.Dtos;
using MyTarefas.Domain;
using MyTarefas.Persistence.Contrato;

namespace MyTarefas.Application
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGeralPersist _geralPersist;

        private readonly IUsuarioPersist _usuarioPersist;

         private readonly IMapper _mapper;

        public UsuarioService(IUsuarioPersist usuarioPersist, IGeralPersist geralPersist, IMapper mapper)
        {
            _usuarioPersist = usuarioPersist;
            _geralPersist = geralPersist;
             _mapper = mapper;
        }

        public Task<UsuarioDto> AddUsuario(long userId, UsuarioDto model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUsuario(long userId)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioDto[]> GetAllByAcompanhamentoIdAsync(long acompanhamentoId)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioDto> UpdateUsuario(long userId, UsuarioDto model)
        {
            throw new NotImplementedException();
        }
    }
}