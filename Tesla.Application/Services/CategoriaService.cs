using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tesla.Application.DTOs;
using Tesla.Application.Interfaces;
using Tesla.Domain.Entidade;
using Tesla.Domain.Interfaces;

namespace Tesla.Application.Services
{
    public class CategoriaService : ICategoriaServices
    {
        private ICategoriaRepository _categoriarepository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriarepository = categoriaRepository;
            _mapper = mapper;
        }


        public async Task Adicionar(CategoriaDTO categoriaDTO)
        {
            var categoriaEntity = _mapper.Map<Categoria>(categoriaDTO);
            await _categoriarepository.AdiconarCategoria(categoriaEntity);
        }

        public async Task<IEnumerable<CategoriaDTO>> ObterCategorias()
        {
            var categoriasEntity = await _categoriarepository.ObterTodasCategoria();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriasEntity);
        }

        public async Task<CategoriaDTO> ObterPorId(int? id)
        {
            var categoriaEntity = await _categoriarepository.ObterCategoriaPorId(id);
            return _mapper.Map<CategoriaDTO>(categoriaEntity);
        }

        public async Task Remover(int? id)
        {
            var categoriaEntity = _categoriarepository.ObterCategoriaPorId(id).Result;
            await _categoriarepository.DeletarCategoria(categoriaEntity);
        }

        public async Task Atualizar(CategoriaDTO categoriaDTO)
        {
            var categoriaEntity = _mapper.Map<Categoria>(categoriaDTO);
            await _categoriarepository.AtualizarCategoria(categoriaEntity);
        }
    }
}
