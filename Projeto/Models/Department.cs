using System;
using System.Linq;
using System.Collections.Generic;

namespace Projeto.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers = new List<Seller>();

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Department()
        {
        }
        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(sellers => sellers.TotalSales(initial, final));
        }
    }
}
