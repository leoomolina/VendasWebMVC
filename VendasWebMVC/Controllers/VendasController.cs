using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMVC.Models;
using VendasWebMVC.Models.ViewModels;
using VendasWebMVC.Services;

namespace VendasWebMVC.Controllers
{
    public class VendasController : Controller
    {
        private readonly VendasService _vendasService;
        private readonly VendedorService _vendedorService;

        public VendasController(VendasService vendasService, VendedorService vendedorService)
        {
            _vendasService = vendasService;
            _vendedorService = vendedorService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BuscaSimples(DateTime? dataMin, DateTime? dataMax)
        {
            if (!dataMin.HasValue)
                dataMin = new DateTime(DateTime.Now.Year, 1, 1);
            
            if (!dataMax.HasValue)
                dataMax = DateTime.Now;

            ViewData["dataMin"] = dataMin.Value.ToString("yyyy-MM-dd");
            ViewData["dataMax"] = dataMax.Value.ToString("yyyy-MM-dd");

            var result = await _vendasService.FindByDateAsync(dataMin, dataMax);

            return View(result);
        }

        public async Task<IActionResult> BuscaAgrupada(DateTime? dataMin, DateTime? dataMax)
        {
            if (!dataMin.HasValue)
                dataMin = new DateTime(DateTime.Now.Year, 1, 1);

            if (!dataMax.HasValue)
                dataMax = DateTime.Now;

            ViewData["dataMin"] = dataMin.Value.ToString("yyyy-MM-dd");
            ViewData["dataMax"] = dataMax.Value.ToString("yyyy-MM-dd");

            var result = await _vendasService.FindByDateGrouping(dataMin, dataMax);

            return View(result);
        }

        public async Task<IActionResult> Cadastro()
        {
            var vendedores = await _vendedorService.FindAllAsync();
            var viewModel = new VendaFormViewModel { Vendedores = vendedores };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(Venda venda)
        {
            if (!ModelState.IsValid)
            {
                var vendedores = await _vendedorService.FindAllAsync();
                var vendaViewModel = new VendaFormViewModel { Venda = venda, Vendedores = vendedores };

                return View(vendaViewModel);
            }

            await _vendasService.InsertAsync(venda);
            return RedirectToAction(nameof(Index));
        }
    }
}
