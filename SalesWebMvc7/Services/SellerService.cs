using Microsoft.EntityFrameworkCore;
using SalesWebMvc7.Data;
using SalesWebMvc7.Models;
using SalesWebMvc7.Services.Exceptions;
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

        public async Task<List<Sellers>> FindAllAsync()
        {
            return await _context.Sellers.ToListAsync();
        }
        // isso vai acessar a minha fonte de dados relacionada a tabela de vendedores e converter para uma lista.

        public async Task InsertAsync(Sellers obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        
        public async Task<Sellers> FindByIdAsync(int id)
        {
            return await _context.Sellers.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
            // nesta abaixo = prof, acima = aluno udemy (que depois o nelio tbm fez pra aparecer o nome do dep na tela de details)
            //_context.Sellers.FirstOrDefault(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Sellers.FindAsync(id);
            _context.Sellers.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Sellers obj)
        {
            bool hasAny = await _context.Sellers.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
