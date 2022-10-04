using System.Collections.Generic;
using System.Threading.Tasks;
using Tesla.Application.DTOs;

namespace Tesla.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDTO>> ObterCategorias();
        Task<CategoriaDTO> ObterPorId(int? id);
        Task Adicionar(CategoriaDTO categoriaDTO);
        Task Atualizar(CategoriaDTO categoriaDTO);
        Task Remover(int? id);
    }
}
