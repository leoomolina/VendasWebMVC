using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMVC.Services;

namespace VendasWebMVC.Controllers
{
    public class VendasController : Controller
    {
        private readonly VendasService _vendasService;

        public VendasController(VendasService vendasService)
        {
            _vendasService = vendasService;
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
    }
}
