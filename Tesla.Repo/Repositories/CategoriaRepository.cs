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
    public class CategoriaRepository : ICategoriaRepository
    {
        ApplicationDbContext _categoriaContext;

        public CategoriaRepository(ApplicationDbContext context)
        {
            _categoriaContext = context;
        }

        public async Task<Categoria> AdiconarCategoria(Categoria categoria)
        {
            _categoriaContext.Add(categoria);
            await _categoriaContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> ObterCategoriaPorId(int? id)
        {
            return await _categoriaContext.Categoria.FindAsync(id);
        }

        public async Task<IEnumerable<Categoria>> ObterTodasCategoria()
        {
            return await _categoriaContext.Categoria.ToListAsync();
        }

        public async Task<Categoria> DeletarCategoria(Categoria categoria)
        {
            _categoriaContext.Remove(categoria);
            await _categoriaContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> AtualizarCategoria(Categoria categoria)
        {
            _categoriaContext.Update(categoria);
            await _categoriaContext.SaveChangesAsync();
            return categoria;
        }
    }
}
