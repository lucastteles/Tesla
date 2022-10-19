using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tesla.Application.DTOs;
using Tesla.Application.Interfaces;
using Tesla.Application.Produtos.Commands;
using Tesla.Application.Produtos.Queries;

namespace Tesla.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProdutoService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoDTO>> ObterProduto()
        {
            var produtosQuery = new GetProdutosQuery();

            if (produtosQuery == null)
                throw new Exception($"Entity could not be loaded.");
            var result = await _mediator.Send(produtosQuery);

            return _mapper.Map<IEnumerable<ProdutoDTO>>(result);
        }

        public async Task<ProdutoDTO> ObterProdutoPorId(int? id)
        {
            var produtosByIdQuery = new GetProdutoByIdQuery(id.Value);

            if (produtosByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");
            var result = await _mediator.Send(produtosByIdQuery);

            return _mapper.Map<ProdutoDTO>(result);
        }

        public async Task AdicionarProduto(ProdutoDTO produtoDTO)
        {//Criar classe DTOToCommandMappingProfile
            var produtoCreateCommand = _mapper.Map<ProdutoCreateCommand>(produtoDTO);
            await _mediator.Send(produtoCreateCommand);
        }

        public async Task AtualizarProduto(ProdutoDTO produtoDTO)
        {
            var produtoUpdateCommand = _mapper.Map<ProdutoUpdateCommand>(produtoDTO);
            await _mediator.Send(produtoUpdateCommand);
        }

        public async Task Remover(int? id)
        {
            var produtoRemoveCommand = new ProdutoRemoveCommand(id.Value);
            if (produtoRemoveCommand == null)
                throw new Exception($"Entity could not loaded.");

            await _mediator.Send(produtoRemoveCommand);
        }
    }
}
