using System;
using System.Linq;
using VendasWebMVC.Models;
using VendasWebMVC.Models.Enums;

namespace VendasWebMVC.Data
{
    public class SeedingService
    {
        private VendasWebMVCContext _context;

        public SeedingService(VendasWebMVCContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Departamento.Any() || _context.Vendedor.Any() || _context.Venda.Any())
                return; // DB já contém dados

            Departamento d1 = new Departamento(1, "Computadores");
            Departamento d2 = new Departamento(2, "Eletrônicos");
            Departamento d3 = new Departamento(3, "Moda");
            Departamento d4 = new Departamento(4, "Livros");

            Vendedor v1 = new Vendedor(1, "Paul Pogba", "pogbinha@gmail.com", new DateTime(1993, 3, 15), 4000, d1);
            Vendedor v2 = new Vendedor(2, "Cristiano Ronaldo", "robozao7@gmail.com", new DateTime(1985, 2, 5), 6500, d2);
            Vendedor v3 = new Vendedor(3, "Neymar Júnior", "meninoney@hotmail.com", new DateTime(1992, 2, 5), 4200, d2);
            Vendedor v4 = new Vendedor(4, "Sergio Ramos Garcia", "sergioramos@gmail.com", new DateTime(1986, 3, 30), 3500, d3);
            Vendedor v5 = new Vendedor(5, "Carlos Henrique Casemiro", "casemito@gmail.com", new DateTime(1992, 2, 23), 3800, d4);

            Venda r1 = new Venda(1, new DateTime(2021, 09, 25), 11000.0, VendaStatus.FATURADO, v1);
            Venda r2 = new Venda(2, new DateTime(2021, 09, 4), 7000.0, VendaStatus.FATURADO, v5);
            Venda r3 = new Venda(3, new DateTime(2021, 09, 13), 4000.0, VendaStatus.CANCELADO, v4);
            Venda r4 = new Venda(4, new DateTime(2021, 09, 1), 8000.0, VendaStatus.FATURADO, v1);
            Venda r5 = new Venda(5, new DateTime(2021, 09, 21), 3000.0, VendaStatus.FATURADO, v3);
            Venda r6 = new Venda(6, new DateTime(2021, 09, 15), 2000.0, VendaStatus.FATURADO, v1);
            Venda r7 = new Venda(7, new DateTime(2021, 09, 28), 13000.0, VendaStatus.FATURADO, v2);
            Venda r8 = new Venda(8, new DateTime(2021, 09, 11), 4000.0, VendaStatus.FATURADO, v4);
            Venda r9 = new Venda(9, new DateTime(2021, 09, 14), 11000.0, VendaStatus.PENDENTE, v2);
            Venda r10 = new Venda(10, new DateTime(2021, 09, 7), 9000.0, VendaStatus.FATURADO, v2);
            Venda r11 = new Venda(11, new DateTime(2021, 09, 13), 6000.0, VendaStatus.FATURADO, v2);
            Venda r12 = new Venda(12, new DateTime(2021, 09, 25), 7000.0, VendaStatus.PENDENTE, v3);
            Venda r13 = new Venda(13, new DateTime(2021, 09, 29), 10000.0, VendaStatus.FATURADO, v4);
            Venda r14 = new Venda(14, new DateTime(2021, 09, 4), 3000.0, VendaStatus.FATURADO, v5);
            Venda r15 = new Venda(15, new DateTime(2021, 09, 12), 4000.0, VendaStatus.FATURADO, v1);
            Venda r16 = new Venda(16, new DateTime(2021, 10, 5), 2000.0, VendaStatus.FATURADO, v4);
            Venda r17 = new Venda(17, new DateTime(2021, 10, 1), 12000.0, VendaStatus.FATURADO, v1);
            Venda r18 = new Venda(18, new DateTime(2021, 10, 24), 6000.0, VendaStatus.FATURADO, v3);
            Venda r19 = new Venda(19, new DateTime(2021, 10, 22), 8000.0, VendaStatus.FATURADO, v5);
            Venda r20 = new Venda(20, new DateTime(2021, 10, 15), 8000.0, VendaStatus.FATURADO, v2);
            Venda r21 = new Venda(21, new DateTime(2021, 10, 17), 9000.0, VendaStatus.FATURADO, v2);
            Venda r22 = new Venda(22, new DateTime(2021, 10, 24), 4000.0, VendaStatus.FATURADO, v4);
            Venda r23 = new Venda(23, new DateTime(2021, 10, 19), 11000.0, VendaStatus.CANCELADO, v2);
            Venda r24 = new Venda(24, new DateTime(2021, 10, 12), 8000.0, VendaStatus.FATURADO, v5);
            Venda r25 = new Venda(25, new DateTime(2021, 10, 31), 7000.0, VendaStatus.FATURADO, v3);
            Venda r26 = new Venda(26, new DateTime(2021, 10, 6), 5000.0, VendaStatus.FATURADO, v4);
            Venda r27 = new Venda(27, new DateTime(2021, 10, 13), 9000.0, VendaStatus.PENDENTE, v1);
            Venda r28 = new Venda(28, new DateTime(2021, 10, 7), 4000.0, VendaStatus.FATURADO, v3);
            Venda r29 = new Venda(29, new DateTime(2021, 10, 23), 12000.0, VendaStatus.FATURADO, v5);
            Venda r30 = new Venda(30, new DateTime(2021, 10, 12), 5000.0, VendaStatus.FATURADO, v2);

            _context.Departamento.AddRange(d1, d2, d3, d4);

            _context.Vendedor.AddRange(v1, v2, v3, v4, v5);

            _context.Venda.AddRange(
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
            );

            _context.SaveChanges();
        }
    }
}
