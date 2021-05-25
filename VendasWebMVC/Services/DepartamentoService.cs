using System.Collections.Generic;
using System.Linq;
using VendasWebMVC.Models;

namespace VendasWebMVC.Services
{
    public class DepartamentoService
    {
        private readonly VendasWebMVCContext _context;

        public DepartamentoService(VendasWebMVCContext context)
        {
            _context = context;
        }

        public List<Departamento> FindAll()
        {
            return _context.Departamento.OrderBy(d => d.Nome).ToList();
        }
    }
}
