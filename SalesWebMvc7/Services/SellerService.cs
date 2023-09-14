using SalesWebMvc7.Data;
using SalesWebMvc7.Models;

namespace SalesWebMvc7.Services
{
    public class SellerService
    {
        private readonly SalesWebMvc7Context _context;        // readonly = previnir que essa dependencia não possa ser alterada, só pode ser lido

        public SellerService (SalesWebMvc7Context context)
        {
            _context = context;
        }
        // dependencia do context

        public List<Sellers> FindAll()
        {
            return _context.Sellers.ToList();
        }
        // isso vai acessar a minha fonte de dados relacionada a tabela de vendedores e converter para uma lista.

        public void Insert(Sellers obj)
        {
            obj.Department = _context.Department.First();
            _context.Add(obj);
            _context.SaveChanges();
        }
        
    }
}
