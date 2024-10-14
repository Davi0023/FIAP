
using Fiap.Web.Challenge.Services;
using Fiap.Web.Challenge.Data.Repository;
using Fiap.Web.Challenge.Models;

namespace Fiap.Web.Challenge.Services
{
    public class SensoresService : ISensoresService
    {
        private readonly ISensoresRepository _repository;
        public SensoresService(ISensoresRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<SensoresModel> ListarSensores() => _repository.GetAll();
        public SensoresModel ObterSensoresPorId(int id) => _repository.GetById(id);
        public void CriarSensores(SensoresModel sensores) => _repository.Add(sensores);
        public void AtualizarSensores(SensoresModel sensores) => _repository.Update(sensores);
        public void DeletarSensores(int id)
        {
            var sensores = _repository.GetById(id);
            if (sensores != null)
                _repository.Delete(sensores);
        }

        public void DeletarSensores(SensoresModel sensores)
        {
            throw new NotImplementedException();
        }
    }
}
