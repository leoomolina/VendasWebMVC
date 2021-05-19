using System;
using System.Collections.Generic;
using System.Linq;

namespace VendasWebMVC.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<Venda> Vendas { get; set; } = new List<Venda>();

        public Vendedor()
        {

        }

        public Vendedor(int id, string name, string email, DateTime dataNascimento, double salarioBase, Departamento departamento)
        {
            Id = id;
            Name = name;
            Email = email;
            DataNascimento = dataNascimento;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AdicionarVenda(Venda venda)
        {
            Vendas.Add(venda);
        }

        public void RemoverVenda(Venda venda)
        {
            Vendas.Remove(venda);
        }

        public double TotalVendas(DateTime dataInicial, DateTime dataFinal)
        {
            return Vendas.Where(v => dataInicial >= v.DataVenda && dataFinal <= v.DataVenda).Sum(v => v.ValorTotal);
        }
    }
}
