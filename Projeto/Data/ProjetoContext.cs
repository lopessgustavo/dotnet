using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Data
{
    public class ProjetoContext : DbContext
    {
        public ProjetoContext (DbContextOptions<ProjetoContext> options)
            : base(options)
        {
        }

        public DbSet<Projeto.Models.Department> Department { get; set; }
    }
}
