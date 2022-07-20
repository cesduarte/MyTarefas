using MyTarefas.Application.Contratos;
using MyTarefas.Domain;
using MyTarefas.Persistence.Contrato;

namespace MyTarefas.Application
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IGeralPersist _geralPersist;

        private readonly IDepartamentoPersist _departamentoPersist;

        public DepartamentoService(IDepartamentoPersist departamentoPersist, IGeralPersist geralPersist)
        {
            _departamentoPersist = departamentoPersist;
            _geralPersist = geralPersist;
        }

        public Task<Departamento> AddDepartamento(int departamentoId, Departamento model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDepartamento(int departamentoId)
        {
            throw new NotImplementedException();
        }

        public Task<Departamento[]> GetAllByCardIdAsync(int cardId)
        {
            throw new NotImplementedException();
        }

        public Task<Departamento> UpdateDepartamento(int departamentoId, Departamento model)
        {
            throw new NotImplementedException();
        }
    }
}