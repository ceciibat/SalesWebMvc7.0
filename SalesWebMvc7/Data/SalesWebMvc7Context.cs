using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc7.Models;

namespace SalesWebMvc7.Data
{
    public class SalesWebMvc7Context : DbContext
    {
        public SalesWebMvc7Context (DbContextOptions<SalesWebMvc7Context> options)
            : base(options)
        {
        }

        public DbSet<SalesWebMvc7.Models.Department> Department { get; set; } = default!;
    }
}
