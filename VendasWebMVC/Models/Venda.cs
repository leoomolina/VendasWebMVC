using System;
using VendasWebMVC.Models.Enums;

namespace VendasWebMVC.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime DataVenda { get; set; }
        public double ValorTotal { get; set; }
        public VendaStatus Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public Venda()
        {
            
        }

        public Venda(int id, DateTime dataVenda, double valorTotal, VendaStatus status, Vendedor vendedor)
        {
            Id = id;
            DataVenda = dataVenda;
            ValorTotal = valorTotal;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
