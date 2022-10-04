using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Tesla.Domain.Entidade;

namespace Tesla.Application.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoDetalhada { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public string ImagemUrl { get; set; }
        public string ImagemThumbaiUrl { get; set; }

        [JsonIgnore]
        public Categoria Categoria { get; set; }

        public int CategoriaId { get; set; }
    }
}
