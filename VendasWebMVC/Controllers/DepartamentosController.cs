using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMVC.Models;

namespace VendasWebMVC.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {
            List<Departamento> list = new List<Departamento>();

            list.Add(new Departamento { Id = 1, Name = "Eletrônicos" });
            list.Add(new Departamento { Id = 2, Name = "Fashion" });

            return View(list);
        }
    }
}
