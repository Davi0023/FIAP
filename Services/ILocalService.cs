using Fiap.Web.Challenge.Models;

namespace Fiap.Web.Challenge.Services
{
    public interface ILocalService
    {
        IEnumerable<LocalModel> ListarLocal();
        LocalModel ObterLocalPorId(int id);
        void CriarLocal(LocalModel Local);
        void AtualizarLocal(LocalModel Local);
        void DeletarLocal(LocalModel Local);

    }
}
