using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tesla.Application.Produtos.Queries;
using Tesla.Domain.Entidade;
using Tesla.Domain.Interfaces;

namespace Tesla.Application.Produtos.Handlers
{
    public class GetProdutoByIdQueryHendler : IRequestHandler<GetProdutoByIdQuery, Produto>
    {
        private readonly IProdutoRepository _produtoRepository;

        public GetProdutoByIdQueryHendler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> Handle(GetProdutoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _produtoRepository.ObterProdutoPorId(request.Id);
        }
    }
}
