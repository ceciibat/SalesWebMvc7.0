﻿using SalesWebMvc7.Data;
using SalesWebMvc7.Models;

namespace SalesWebMvc7.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvc7Context _context;

        public DepartmentService(SalesWebMvc7Context context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
