using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Application.DTOs;
using Tesla.Application.Interfaces;
using Tesla.Domain.Entidade;
using Tesla.Domain.Interfaces;

namespace Tesla.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        //private IProdutoRepository _produtoRepository; // Usar IMediator
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoDTO>> ObterProduto()
        {
            var produtoEntity = await _produtoRepository.ObterTodosProdutos();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtoEntity);
        }

        public async Task<ProdutoDTO> ObterProdutoPorId(int? id)
        {
            var produtoEntity = await _produtoRepository.ObterProdutoPorId(id);
            return _mapper.Map<ProdutoDTO>(produtoEntity);
        }

        public async Task AdicionarProduto(ProdutoDTO produto)
        {
            var produtoEntity = _mapper.Map<Produto>(produto);
            await _produtoRepository.AdicionarProduto(produtoEntity);
        }

        public async Task AtualizarProduto(ProdutoDTO produto)
        {
            var produtoEntity = _mapper.Map<Produto>(produto);
            await _produtoRepository.AtualizarProduto(produtoEntity);
        }

        public async Task Remover(int? id)
        {
            var produtoEntity = _produtoRepository.ObterProdutoPorId(id).Result;
            await _produtoRepository.RemoverProduto(produtoEntity);
        }
    }
}
