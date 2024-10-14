
using Fiap.Web.Challenge.Services;
using Fiap.Web.Challenge.Data.Repository;
using Fiap.Web.Challenge.Models;

namespace Fiap.Web.Challenge.Services
{
    public class LocalService : ILocalService
    {
        private readonly ILocalRepository _repository;
        public LocalService(ILocalRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<LocalModel> ListarLocal() => _repository.GetAll();
        public LocalModel ObterLocalPorId(int id) => _repository.GetById(id);
        public void CriarLocal(LocalModel local) => _repository.Add(local);
        public void AtualizarLocal(LocalModel local) => _repository.Update(local);
        public void DeletarLocal(int id)
        {
            var local = _repository.GetById(id);
            if (local != null)
                _repository.Delete(local);
        }

        public void DeletarLocal(LocalModel Local)
        {
            throw new NotImplementedException();
        }
    }
}
