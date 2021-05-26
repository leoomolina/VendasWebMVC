using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VendasWebMVC.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public int DepartamentoId { get; set; }
        
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} deve conter de {2} a {1} caracteres.")]
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Entre com um e-mail válido.")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string Email { get; set; }
        
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public DateTime DataNascimento { get; set; }
        
        [Display(Name = "Salário Base")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [Range(100, 50000, ErrorMessage = "{0} deve ser entre {1} e {2}.")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<Venda> Vendas { get; set; } = new List<Venda>();

        public Vendedor()
        {

        }

        public Vendedor(int id, string nome, string email, DateTime dataNascimento, double salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
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
            return Vendas.Where(v => v.DataVenda >= dataInicial && v.DataVenda <= dataFinal).Sum(v => v.ValorTotal);
        }
    }
}
