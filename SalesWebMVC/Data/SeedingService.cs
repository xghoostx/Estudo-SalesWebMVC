using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;
using System;
using System.Linq;


namespace SalesWebMVC.Data
{
    public class SeedingService
    {
        private SalesWebMVCContext _context;

        public SeedingService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any() )
            {
                return; // DB já possui elementos salvos
            }

            //instanciando os objetos
            Department d1 = new Department(1, "Computer");
            Department d2 = new Department(2, "Smarthfone");
            Department d3 = new Department(3, "Book");

            Seller s1 = new Seller(1, "vendedor 1 ", "vendedor1@gmail.com", new DateTime(1996,12,28), 1000.0, d1);
            Seller s2 = new Seller(2, "vendedor 2 ", "vendedor2@gmail.com", new DateTime(1997, 2, 7), 1000.0, d1);
            Seller s3 = new Seller(3, "vendedor 3 ", "vendedor3@gmail.com", new DateTime(1998, 8, 6), 1000.0, d2);
            Seller s4 = new Seller(4, "vendedor 4 ", "vendedor4@gmail.com", new DateTime(1996, 12, 28), 1000.0, d2);
            Seller s5 = new Seller(5, "vendedor 5 ", "vendedor5@gmail.com", new DateTime(2000, 2, 23), 1000.0, d3);
            Seller s6 = new Seller(6, "vendedor 6 ", "vendedor6@gmail.com", new DateTime(2002, 8, 6), 1000.0, d3);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2019, 01, 3), 2300.0, SaleStatus.Billed, s1);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2019, 01, 2), 2000.0, SaleStatus.Pending, s3);
            SalesRecord sr3 = new SalesRecord(3, new DateTime(2019, 01, 1), 978.50, SaleStatus.Billed, s4);
            SalesRecord sr4 = new SalesRecord(4, new DateTime(2019, 01, 3), 3800.0, SaleStatus.Canceled, s1);
        
            // Adicionando os elementos no BD
            _context.Department.AddRange(d1, d2, d3);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SalesRecord.AddRange(sr1, sr2, sr3, sr4);
            _context.SaveChanges(); // Salvando e confirmando os dados no DB
        }
    }
}
