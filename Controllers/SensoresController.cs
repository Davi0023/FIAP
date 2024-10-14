//using Fiap.Web.Challenge.Data.Contexts;
//using Fiap.Web.Challenge.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;

//namespace Fiap.Web.Challenge.Controllers
//{
//    public class SensoresController : Controller
//    {

//        private readonly DatabaseContext _context;
//        public SensoresController(DatabaseContext context)
//        {
//            _context = context;
//        }


//        //public List<SensoresModel> sensores { get; set; }
//        //public List<LocalModel> local { get; set; }

//        //public SensoresController()
//        //{
//        //    sensores = CadastroSensores();
//        //    local = CadastroLocal();
//        //}

//        public IActionResult Index()
//        {
//            // O método Include será explicado posteriomente
//            var sensores = _context.Sensores.Include(c => c.Local).ToList();
//            return View(sensores);
//        }


//        //public IActionResult Index()
//        //{
//        //    if(sensores == null)
//        //    {
//        //        sensores = new List<SensoresModel>();
//        //    }

//        //    return View(sensores);
//        //}

//        [HttpGet]
//        public IActionResult Cadastro()
//        {
//            Console.WriteLine("Cadastro do sensor realizado!");

//            var selectListLocal =
//                new SelectList(local,
//                                nameof(LocalModel.id_local),
//                                nameof(LocalModel.ds_coordenadas));

//            ViewBag.Local = selectListLocal;

//            return View(new SensoresModel());
//        }

//        [HttpPost]
//        public IActionResult Cadastro(SensoresModel sensoresModel)
//        {
//            _context.Sensores.Add(sensoresModel);
//            _context.SaveChanges();
//            TempData["mensagemSucesso"] = $"O sensor {sensoresModel.ds_modelo} foi cadastrado com sucesso";
//            return RedirectToAction(nameof(Index));
//        }


//        //[HttpPost]
//        //public IActionResult Cadastro(SensoresModel sensoresModel)
//        //{
//        //    Console.WriteLine("Cadastrando o sensor!");

//        //    TempData["mensagemSucesso"] = $"O sensor {sensoresModel.ds_modelo} foi cadastrado com sucesso!";

//        //    return RedirectToAction(nameof(Index));
//        //}

//        //Anotação de uso do Verb HTTP Get
//        // Anotação de uso do Verb HTTP Get
//        [HttpGet]
//        public IActionResult Edit(int id)
//        {
//            var sensor = _context.Sensores.Find(id);
//            if (sensor == null)
//            {
//                return NotFound();
//            }
//            else
//            {
//                ViewBag.Local =
//                    new SelectList(_context.Sensores.ToList(),
//                                    "id_sensor",
//                                    "ds_modelo",
//                                    sensor.id_sensor);
//                return View(sensor);
//            }
//        }

//        //[HttpGet]
//        //public IActionResult Edit(int id)
//        //{
//        //    var selectListLocal = 
//        //        new SelectList(local,
//        //                        nameof(LocalModel.id_local),
//        //                        nameof(LocalModel.ds_coordenadas));
//        //    ViewBag.Local = selectListLocal;

//        ////Simulando a busca no D.B.
//        //var sensorconsultado = 
//        //        sensores.Where(s => s.id_sensor == id).FirstOrDefault();

//        //    return View(sensorconsultado);
//        //}

//        [HttpPost]
//        public IActionResult Edit(SensoresModel sensoresModel)
//        {
//            _context.Update(sensoresModel);
//            _context.SaveChanges();
//            TempData["mensagemSucesso"] = $"Os dados do sensor {sensoresModel.ds_modelo} foram alterados com sucesso";
//            return RedirectToAction(nameof(Index));
//        }


//        //[HttpPost]
//        //public IActionResult Edit(SensoresModel sensoresModel)
//        //{
//        //    TempData["mensagemSucesso"] = $"Os dados do sensor {sensoresModel.ds_modelo} foram editado com sucesso!";

//        //    return RedirectToAction(nameof(Index));
//        //}

//        //Método Detail
//        // Anotação de uso do Verb HTTP Get
//        [HttpGet]
//        public IActionResult Detail(int id)
//        {
//            // Usando o método Include 
//            var sensores = _context.Sensores
//                            .Include(c => c.Sensores) // Carrega o representante junto com o sensor
//                            .FirstOrDefault(c => c.id_sensor == id); // Encontra o sensor pelo id
//            if (sensores == null)
//            {
//                return NotFound(); // Retorna um erro 404 se o sensor não for encontrado
//            }
//            else
//            {
//                return View(sensores); // Retorna a view com os dados do sensor e seu representante
//            }
//        }


//        //[HttpGet]
//        //public IActionResult Detail(int id)
//        //{

//        //    var selectListLocal =
//        //        new SelectList(local,
//        //                        nameof(LocalModel.id_local),
//        //                        nameof(LocalModel.ds_coordenadas));

//        //    ViewBag.Local = selectListLocal;

//        //    // Simulando a busca no banco de dados 
//        //    var SensorConsultado =
//        //        sensores.Where(s => s.id_sensor == id).FirstOrDefault();

//        //    // Retornando o sensor consultado para a View
//        //    return View(SensorConsultado);
//        //}


//        // Anotação de uso do Verb HTTP Get
//        [HttpGet]
//        public IActionResult Delete(int id)
//        {
//            var sensores = _context.Sensores.Find(id);
//            if (sensores != null)
//            {
//                _context.Sensores.Remove(sensores);
//                _context.SaveChanges();
//                TempData["mensagemSucesso"] = $"Os dados do sensor {sensores.ds_modelo} foram removidos com sucesso";
//            }
//            else
//            {
//                TempData["mensagemSucesso"] = "OPS !!! Sensor inexistente.";
//            }
//            return RedirectToAction(nameof(Index));
//        }

//        //[HttpGet]
//        //public IActionResult Delete(int id)
//        //{
//        //    // Simulando a busca no banco de dados 
//        //    var SensorConsultado =
//        //        sensores.Where(s => s.id_sensor == id).FirstOrDefault();

//        //    if (SensorConsultado != null)
//        //    {
//        //        TempData["mensagemSucesso"] = $"Os dados do sensor {SensorConsultado.ds_modelo} foram removidos com sucesso";
//        //    }
//        //    else
//        //    {
//        //        TempData["mensagemSucesso"] = $"OPS !!! Sensor inexistente.";
//        //    }

//        //    return RedirectToAction(nameof(Index));
//        //}

//        public static List<LocalModel> CadastroLocal()
//        {
//            var local = new List<LocalModel>
//            {
//                new LocalModel { id_local = 1, ds_coordenadas = "Coordenadas 1", nm_oceano = "Atlântico" },
//                new LocalModel { id_local = 2, ds_coordenadas = "Coordenadas 2", nm_oceano = "Pacífico" },
//                new LocalModel { id_local = 3, ds_coordenadas = "Coordenadas 3", nm_oceano = "Ártico" },
//                new LocalModel { id_local = 4, ds_coordenadas = "Coordenadas 4", nm_oceano = "Atlantico" }
//            };

//            return local;
//        }


//        public static List<SensoresModel> CadastroSensores()
//        {
//            var sensores = new List<SensoresModel>();
//            for (int i = 1; i <= 5; i++)
//            {
//                var sensor = new SensoresModel
//                {
//                    id_sensor = i,
//                    ds_modelo = "Sensor" + i,
//                    ds_fabricante = "Fabricante" + i,
//                    nm_oceano = "Oceano" + i,
//                    id_local = i,
//                    Local = new LocalModel
//                    {
//                        id_local = i,
//                        ds_coordenadas = "Coordenadas" + i,
//                        nm_oceano = "Oceano" + i
//                    }
//                };

//                sensores.Add(sensor);
//            }

//            return sensores;
//        }
//    }
//}

//////////////////////////////////////////////////////////////////////////////
///
using AutoMapper;
using Fiap.Web.Challenge.Data.Contexts;
using Fiap.Web.Challenge.Models;
using Fiap.Web.Challenge.Models.ViewModels;
using Fiap.Web.Challenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace Fiap.Web.Challenge.Controllers
{
    public class SensoresController : Controller
    {


        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        private readonly ILocalService _localService;
        private readonly ISensoresService _sensoresService;
        public SensoresController( IMapper mapper, ILocalService localService, ISensoresService sensoresService)
        {
            _mapper = mapper;
            _localService = localService;
            _sensoresService = sensoresService;
        }
        public IActionResult Index()
        {
            var sensores = _sensoresService.ListarSensores();
            return View(sensores);
        }
        //[HttpGet]
        //public IActionResult Cadastro()
        //{
        //    ViewBag.Sensores =
        //        new SelectList(_context.Sensores.ToList()
        //                        , "id_sensor"
        //                        , "ds_modelo");
        //    return View();
        //}

        [HttpGet]
        public IActionResult Cadastro()
        {

            var viewModel = new SensoresCadastroViewModel
            {
                Local = new SelectList(_localService.ListarLocal()
                                , "id_local"
                                , "ds_coordenadas")
            };

            return View(viewModel);
        }
        // Anotação de uso do Verb HTTP Post
        [HttpPost]
        public IActionResult Cadastro(SensoresCadastroViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var sensoresModel = _mapper.Map<SensoresModel>(viewModel);

                _sensoresService.CriarSensores(sensoresModel);
                TempData["mensagemSucesso"] = $"O sensor {sensoresModel.id_sensor} foi cadastrado com sucesso";
                return RedirectToAction(nameof(Index));
            } else
            { 
                viewModel.Local = new SelectList(_context.Local.ToList()
                                , "id_local"
                                , "ds_coordenadas");
                return View(viewModel);
            }
        }


        //[HttpPost]
        //public IActionResult Cadastro(SensoresModel sensoresModel)
        //{
        //    _context.Sensores.Add(sensoresModel);
        //    _context.SaveChanges();
        //    TempData["mensagemSucesso"] = $"O sensor {sensoresModel.ds_modelo} foi cadastrado com sucesso";
        //    return RedirectToAction(nameof(Index));
        //}
        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public IActionResult Detail(int id)
        {
            // Usando o método Include para carregar o local associado
            var sensores = _sensoresService.ObterSensoresPorId(id);
            if (sensores == null) return NotFound();
            return View(sensores);
        }
        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var sensores = _sensoresService.ObterSensoresPorId(id);
            if (sensores == null)
            {
                return NotFound();
            }

            else
            {
                ViewBag.Local =
                    new SelectList(_context.Local.ToList(),
                                    "id_local",
                                    "ds_coordenadas",
                                    sensores.id_local);
                return View(sensores);
            }
        }
        [HttpPost]
        public IActionResult Edit(SensoresModel sensoresModel)
        {
            _sensoresService.AtualizarSensores(sensoresModel);
            TempData["mensagemSucesso"] = $"Os dados do sensor {sensoresModel.ds_modelo} foram alterados com sucesso";
            return RedirectToAction(nameof(Index));
        }
        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    _sensoresService.DeletarSensores(id); 
        //    TempData["mensagemSucesso"] = $"Os dados do sensor foram removidos com sucesso";
        //    return RedirectToAction(nameof(Index));
        //}

        //public static List<LocalModel> CadastroLocal()
        //{
        //    var local = new List<LocalModel>
        //    {
        //        new LocalModel { id_local = 1, ds_coordenadas = "Coordenadas 1", nm_oceano = "Atlântico" },
        //        new LocalModel { id_local = 2, ds_coordenadas = "Coordenadas 2", nm_oceano = "Pacífico" },
        //        new LocalModel { id_local = 3, ds_coordenadas = "Coordenadas 3", nm_oceano = "Ártico" },
        //        new LocalModel { id_local = 4, ds_coordenadas = "Coordenadas 4", nm_oceano = "Atlantico" }
        //    };

        //    return local;
        //}


        //public static List<SensoresModel> CadastroSensores()
        //{
        //    var sensores = new List<SensoresModel>();
        //    for (int i = 1; i <= 5; i++)
        //    {
        //        var sensor = new SensoresModel
        //        {
        //            id_sensor = i,
        //            ds_modelo = "Sensor" + i,
        //            ds_fabricante = "Fabricante" + i,
        //            nm_oceano = "Oceano" + i,
        //            id_local = i,
        //            Local = new LocalModel
        //            {
        //                id_local = i,
        //                ds_coordenadas = "Coordenadas" + i,
        //                nm_oceano = "Oceano" + i
        //            }
        //        };

        //        sensores.Add(sensor);
        //    }

        //    return sensores;
        //}
    }
}

