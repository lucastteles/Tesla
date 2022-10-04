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
    public class ProdutoCreateCommandHendler : IRequestHandler<ProdutoCreateCommand, Produto>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoCreateCommandHendler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> Handle(ProdutoCreateCommand request,
            CancellationToken cancellationToken)
        {
            var produto = new Produto(request.Nome, request.DescricaoCurta, request.DescricaoDetalhada, request.Preco,
                                     request.Estoque, request.ImagemUrl, request.ImagemThumbaiUrl);

            if (produto == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                produto.CategoriaId = request.CategoriaId;
                return await _produtoRepository.AdicionarProduto(produto);
            }
        }
    }
}
