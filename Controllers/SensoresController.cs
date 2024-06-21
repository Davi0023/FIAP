using Fiap.Web.Challenge.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Challenge.Controllers
{
    public class SensoresController : Controller
    {
        private List<SensoresModel> _sensores;
        public SensoresController()
        {
            _sensores = CadastroSensores;
        }


        public IActionResult Index()
        {
            Console.WriteLine(_sensores.Count);

            return View();
        }


        public static List<SensoresModel> CadastroSensores()
        {
            var sensores = new List<SensoresModel>();
            for (int i = 1; i <= 5; i++)
            {
                var sensor = new SensoresModel
                {
                    id_sensor = i,
                    ds_modelo = "Sensor" + i,
                    ds_fabricante = "Fabricante" + i,
                    id_oceano = "Oceano" + i,
                    id_local = new LocalModel
                    {
                        id_local = i,
                        ds_coordenadas = "Coordenadas" + i,
                        id_orgao = new OrgaoModel
                        {
                            id_orgao = i,
                            nm_orgao = "Orgao" + i
                        }
                    }
                };
            }
        }
    }
}
