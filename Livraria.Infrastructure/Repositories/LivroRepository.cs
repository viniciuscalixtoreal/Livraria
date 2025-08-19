using Livraria.Domain.Abstractions;
using Livraria.Domain.Entities;
using Livraria.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Infrastructure.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly AppDbContext _context;

        public LivroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Livro>> ObterLivros()
        {
            return await _context.Livros.ToListAsync();
        }

        public async Task<Livro?> ObterLivro(int id)
        {
            return await _context.Livros.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Livro> AdicionarLivro(Livro livro)
        {
            if (livro is not null)
            {
                _context.Livros.Add(livro);
                await _context.SaveChangesAsync();
                return livro;
            }

            throw new InvalidOperationException("Dados inválidos.");
        }

        public async Task AtualizarLivro(Livro livro)
        {
            if (livro is not null)
            {
                _context.Livros.Update(livro);
                await _context.SaveChangesAsync();
            }

            throw new InvalidOperationException("Dados inválidos.");
        }

        public async Task DeletarLivro(int id)
        {
            var obj = await _context.Livros.FirstOrDefaultAsync(x => x.Id == id);

            if (obj is not null)
            {
                _context.Livros.Remove(obj);
                await _context.SaveChangesAsync();
            }

            throw new InvalidOperationException("Dados inválidos.");
        }
    }
}
