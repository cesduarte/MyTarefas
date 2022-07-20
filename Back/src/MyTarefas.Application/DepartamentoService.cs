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

        public async Task<Departamento> AddDepartamento(int departamentoId, Departamento model)
        {
            try
            {

                _geralPersist.Add<Departamento>(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var departamentoRetorno = await _departamentoPersist.GetByDepartamentoIdAsync(model.Id);

                    return departamentoRetorno;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Departamento> UpdateDepartamento(int departamentoId, Departamento model)
        {
            try
            {
                var departamento = await _departamentoPersist.GetByDepartamentoIdAsync(departamentoId);

                if (departamento == null) return null;

                model.Id = departamento.Id;

                _geralPersist.Update<Departamento>(departamento);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var departamentoRetorno = await _departamentoPersist.GetByDepartamentoIdAsync(model.Id);

                    return departamentoRetorno;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteDepartamento(int departamentoId)
        {
            try
            {
                var departamento = await _departamentoPersist.GetByDepartamentoIdAsync(departamentoId);

                if (departamento == null) throw new Exception("Departamento não encontrado.");

                _geralPersist.Delete<Departamento>(departamento);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Departamento[]> GetAllByCardIdAsync(int cardId)
        {
           var departamento  = await _departamentoPersist.GetAllByCardIdAsync(cardId);

            if ( departamento == null) return null;

            return departamento;
        }

    }
}