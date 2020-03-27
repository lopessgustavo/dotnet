using Projeto.Data;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Services
{
    public class SellerService
    {
        private readonly ProjetoContext _context;

        public SellerService(ProjetoContext context)
        {
            _context = context;
        }
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }
    }
}
