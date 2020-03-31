using Projeto.Data;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto.Services.Exceptions;

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
        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }
        public void Remove(int id)
        {
            var seller = _context.Seller.Find(id);
            _context.Seller.Remove(seller);
            _context.SaveChanges();
        }

        public void Update(Seller seller)
        {
            if (!_context.Seller.Any(x => x.Id == seller.Id)) throw new NotFoundException("Not Found");

            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new DBConcurrencyException(e.Message);
            }
            
        }
    }
}
