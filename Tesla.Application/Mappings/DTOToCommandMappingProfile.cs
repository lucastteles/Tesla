using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Application.DTOs;
using Tesla.Application.Produtos.Commands;

namespace Tesla.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProdutoDTO, ProdutoCreateCommand>();
            CreateMap<ProdutoDTO, ProdutoUpdateCommand>();
        }
    }
}
