using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMVC.Models;

namespace VendasWebMVC.Services
{
    public class VendasService
    {
        private readonly VendasWebMVCContext _context;

        public VendasService(VendasWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Venda>> FindByDateAsync(DateTime? dataMin, DateTime? dataMax)
        {
            var result = from obj in _context.Venda select obj;

            if (dataMin.HasValue)
                result = result.Where(v => v.DataVenda >= dataMin.Value);

            if (dataMax.HasValue)
                result = result.Where(v => v.DataVenda <= dataMax.Value);

            return await result
                        .Include(i => i.Vendedor).Include(i => i.Vendedor.Departamento)
                        .OrderByDescending(i => i.DataVenda).ToListAsync();
        }

        public async Task<List<IGrouping<Departamento, Venda>>> FindByDateGrouping(DateTime? dataMin, DateTime? dataMax)
        {
            var result = from obj in _context.Venda select obj;

            if (dataMin.HasValue)
                result = result.Where(v => v.DataVenda >= dataMin.Value);

            if (dataMax.HasValue)
                result = result.Where(v => v.DataVenda <= dataMax.Value);

            return await result
                        .Include(i => i.Vendedor).Include(i => i.Vendedor.Departamento)
                        .GroupBy(v => v.Vendedor.Departamento).ToListAsync();
        }

        public async Task InsertAsync(Venda obj)
        {
            obj.Status = Models.Enums.VendaStatus.PENDENTE;
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}
