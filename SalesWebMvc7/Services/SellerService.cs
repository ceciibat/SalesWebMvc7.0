using Microsoft.EntityFrameworkCore;
using SalesWebMvc7.Data;
using SalesWebMvc7.Models;
using System;

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
            _context.Add(obj);
            _context.SaveChanges();
        }
        
        public Sellers FindById(int id)
        {
            return _context.Sellers.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
            // nesta abaixo = prof, acima = aluno udemy (que depois o nelio tbm fez pra aparecer o nome do dep na tela de details)
            //_context.Sellers.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Sellers.Find(id);
            _context.Sellers.Remove(obj);
            _context.SaveChanges();
        }
    }
}
