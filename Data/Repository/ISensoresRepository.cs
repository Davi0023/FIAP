using Fiap.Web.Challenge.Models;
namespace Fiap.Web.Challenge.Data.Repository
{
    public interface ISensoresRepository
    {
        IEnumerable<SensoresModel> GetAll();
        SensoresModel GetById(int id);
        void Add(SensoresModel sensores);
        void Update(SensoresModel sensores);
        void Delete(SensoresModel sensores);

    }
}
