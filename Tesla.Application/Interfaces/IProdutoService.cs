using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Application.DTOs;

namespace Tesla.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> ObterProduto();
        Task<ProdutoDTO> ObterProdutoPorId(int? id);
        Task AdicionarProduto(ProdutoDTO produto);
        Task AtualizarProduto(ProdutoDTO produto);
        Task Remover(int? id);
    }
}
