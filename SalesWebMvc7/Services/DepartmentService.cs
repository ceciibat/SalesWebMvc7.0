using SalesWebMvc7.Data;
using SalesWebMvc7.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc7.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvc7Context _context;

        public DepartmentService(SalesWebMvc7Context context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
