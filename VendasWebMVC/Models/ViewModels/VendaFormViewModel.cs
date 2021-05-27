using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWebMVC.Models.ViewModels
{
    public class VendaFormViewModel
    {
        public Venda Venda { get; set; }

        public ICollection<Vendedor> Vendedores { get; set; }
    }
}
