using Fiap.Web.Challenge.Models;

namespace Fiap.Web.Challenge.Services
{
    public interface ISensoresService
    {
        IEnumerable<SensoresModel> ListarSensores();
        SensoresModel ObterSensoresPorId(int id);
        void CriarSensores(SensoresModel sensores);
        void AtualizarSensores(SensoresModel sensores);
        void DeletarSensores(SensoresModel sensores);

    }
}
