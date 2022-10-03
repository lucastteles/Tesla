using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Domain.Entidade;

namespace Tesla.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> ObterTodosProdutos();
        Task<Produto> ObterProdutoPorId(int? id);
        Task<Produto> AdicionarProduto(Produto produto);
        Task<Produto> AtualizarProduto(Produto produto);
        Task<Produto> RemoverProduto(Produto produto);
    }
}
