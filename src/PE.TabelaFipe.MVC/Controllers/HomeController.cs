using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PE.TabelaFipe.Domain;
using PE.TabelaFipe.MVC.Models;
using PE.TabelaFipe.MVC.ViewModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PE.TabelaFipe.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITabelaFipeService _tabelaFipeService;
        private readonly IMapper _mapper;

        public HomeController(
            ILogger<HomeController> logger,
            ITabelaFipeService tabelaFipeService,
            IMapper mapper)
        {
            _logger = logger;
            _tabelaFipeService = tabelaFipeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var fipeDTO = new FipeDTO();

            await Task.CompletedTask;

            return View(fipeDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string marca, int codigoMarca = default, int codigoModelo = default, string codigoAno = "")
        {
            var fipeDTO = new FipeDTO();            

            if (!string.IsNullOrWhiteSpace(marca))
            {
                var marcas = _mapper.Map<List<MarcaViewModel>>(await _tabelaFipeService.ObterMarcas(marca));
                fipeDTO.Marcas = marcas;
                fipeDTO.Marca = marca;
            }
            if(codigoMarca > default(int))
            {
                var modelos = _mapper.Map<List<ModeloViewModel>>(await _tabelaFipeService.ObterModelos(marca, codigoModelo));
                fipeDTO.Modelos = modelos;
                fipeDTO.CodigoMarca = codigoMarca;
            }
            if (codigoModelo > default(int))
            {
                var modelosPorAno = _mapper.Map<List<ModeloViewModel>>(await _tabelaFipeService.ObterModelosPorAno(marca, codigoMarca, codigoModelo));
                fipeDTO.ModelosPorAno = modelosPorAno;
                fipeDTO.CodigoModelo = codigoModelo;
            }
            if (!string.IsNullOrWhiteSpace(codigoAno))
            {
                var modelosPorAno = _mapper.Map<List<ModeloViewModel>>(await _tabelaFipeService.ObterModelosPorAno(marca, codigoMarca, codigoModelo));
                fipeDTO.ModelosPorAno = modelosPorAno;
                fipeDTO.CodigoAno = codigoAno;
            }
            if (codigoMarca > default(int) && codigoModelo > default(int) && !string.IsNullOrWhiteSpace(codigoAno))
            {
                var preco = _mapper.Map<FipeViewModel>(await _tabelaFipeService.ObterPreco(marca, codigoMarca, codigoModelo, codigoAno));
                fipeDTO.Fipe = preco;                
            }

            return View("Index",fipeDTO);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
