using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWebMVC.Models.ViewModels
{
    public class BuscaSimplesViewModel
    {
        public DateTime DataMin { get; set; }
        public DateTime DataMax { get; set; }
        public ICollection<Venda> Vendas { get; set; }
    }
}
