using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWebMVC.Models
{
    public class Departamento
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();

        public Departamento()
        {

        }

        public Departamento(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AdicionarVendedor(Vendedor vendedor)
        {
            Vendedores.Add(vendedor);
        }

        public double TotalVendas(DateTime dataInicial, DateTime dataFinal)
        {
            return Vendedores.Sum(v => v.TotalVendas(dataInicial, dataFinal));
        }
    }
}   
