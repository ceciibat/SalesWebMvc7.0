using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc7.Models;

namespace SalesWebMvc7.Data
{
    public class SalesWebMvc7Context : DbContext
    {
        //O DbContext é uma abstração para trabalhar com o ObjectContext,
        //responsável pelo contexto dos dados, incluindo o estado das entidades e suas conexões. 

        public SalesWebMvc7Context (DbContextOptions<SalesWebMvc7Context> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; } = default!;
        public DbSet<Sellers> Sellers { get; set; }
        public DbSet<SalesRecord> SalesRecords { get; set; }

    }
}
