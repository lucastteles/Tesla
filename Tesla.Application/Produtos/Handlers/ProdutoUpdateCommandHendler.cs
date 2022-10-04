using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tesla.Application.Produtos.Commands;
using Tesla.Domain.Entidade;
using Tesla.Domain.Interfaces;

namespace Tesla.Application.Produtos.Handlers
{
    public class ProdutoUpdateCommandHendler : IRequestHandler<ProdutoUpdateCommand, Produto>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoUpdateCommandHendler(IProdutoRepository produtoRepository)
        {
            produtoRepository = produtoRepository ??
                throw new ArgumentNullException(nameof(produtoRepository));
        }

        public async Task<Produto> Handle(ProdutoUpdateCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.ObterProdutoPorId(request.Id);

            if (produto == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                produto.Update(request.Nome, request.DescricaoCurta, request.DescricaoDetalhada, request.Preco,
                              request.Estoque, request.ImagemUrl, request.ImagemThumbaiUrl, request.CategoriaId);

                return await _produtoRepository.AtualizarProduto(produto);
            }
        }
    }
}
