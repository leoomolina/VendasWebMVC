using System;
using System.ComponentModel.DataAnnotations;
using VendasWebMVC.Models.Enums;

namespace VendasWebMVC.Models
{
    public class Venda
    {
        public int Id { get; set; }

        public int VendedorId { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório!")]
        [Display(Name = "Data da Venda")]
        [DataType(DataType.Date)]
        public DateTime DataVenda { get; set; }
        
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [Display(Name = "Valor Total")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
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
