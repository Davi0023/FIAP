using Fiap.Web.Challenge.Models;

namespace Fiap.Web.Challenge.Data.Repository
{
    public interface ILocalRepository
    {
        IEnumerable<LocalModel> GetAll();
        LocalModel GetById(int id);
        void Add(LocalModel local);
        void Update(LocalModel local);
        void Delete(LocalModel local);
    }
}
