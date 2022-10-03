using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Domain.Entidade;
using Tesla.Domain.Interfaces;
using Tesla.Repo.Context;

namespace Tesla.Repo.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        ApplicationDbContext _produtoContext;

        public ProdutoRepository(ApplicationDbContext context)
        {
            _produtoContext = context;
        }

        public async Task<Produto> AdicionarProduto(Produto produto)
        {
            _produtoContext.Add(produto);
            await _produtoContext.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> AtualizarProduto(Produto produto)
        {
            _produtoContext.Update(produto);
            await _produtoContext.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> ObterProdutoPorId(int? id)
        {
            return await _produtoContext.Produto.Include(c=> c.Categoria)
                .SingleOrDefaultAsync(p=> p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterTodosProdutos()
        {
            return await _produtoContext.Produto.ToListAsync();
        }

        public async Task<Produto> RemoverProduto(Produto produto)
        {
            _produtoContext.Remove(produto);
            await _produtoContext.SaveChangesAsync();
            return produto;
        }
    }
}
