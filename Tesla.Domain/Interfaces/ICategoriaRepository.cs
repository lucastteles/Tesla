using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Domain.Entidade;

namespace Tesla.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> ObterTodasCategoria();
        Task<Categoria> ObterCategoriaPorId(int? id);
        Task<Categoria> AdiconarCategoria(Categoria categoria);
        Task<Categoria> AtualizarCategoria(Categoria categoria);
        Task<Categoria> DeletarCategoria(Categoria categoria);
    }
}
