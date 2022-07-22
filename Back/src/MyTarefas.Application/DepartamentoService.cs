using AutoMapper;
using MyTarefas.Application.Contratos;
using MyTarefas.Application.Dtos;
using MyTarefas.Domain;
using MyTarefas.Persistence.Contrato;

namespace MyTarefas.Application
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IGeralPersist _geralPersist;

        private readonly IDepartamentoPersist _departamentoPersist;

         private readonly IMapper _mapper;

        public DepartamentoService(IDepartamentoPersist departamentoPersist, IGeralPersist geralPersist, IMapper mapper)
        {
            _departamentoPersist = departamentoPersist;
            _geralPersist = geralPersist;
             _mapper = mapper;
        }

        public Task<DepartamentoDto> AddDepartamento(long departamentoId, DepartamentoDto model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDepartamento(long departamentoId)
        {
            throw new NotImplementedException();
        }

        public Task<DepartamentoDto[]> GetAllByCardIdAsync(long cardId)
        {
            throw new NotImplementedException();
        }

        public Task<DepartamentoDto> UpdateDepartamento(long departamentoId, DepartamentoDto model)
        {
            throw new NotImplementedException();
        }
    }
}