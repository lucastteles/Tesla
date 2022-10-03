using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Domain.Validacao;

namespace Tesla.Domain.Entidade
{
    public sealed class Produto : EntidadeBase
    {
        //public int Id { get; private set; }
        public string Nome { get; private set; }
        public string DescricaoCurta { get; private set; }
        public string DescricaoDetalhada { get; private set; }
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }
        public string ImagemUrl { get; private set; }
        public string ImagemThumbaiUrl { get; private set; }

        public Produto(string nome, string descricaoCurta, string descricaoDetalhada, decimal preco, int estoque, string imagemUrl, string imagemThumbaiUrl)
        {
            ValidateDomain(nome, descricaoCurta, descricaoDetalhada, preco, estoque, imagemUrl, imagemThumbaiUrl);
        }

        public Produto(int id, string nome, string descricaoCurta, string descricaoDetalhada, decimal preco, int estoque, string imagemUrl, string imagemThumbaiUrl)
        {
            DomainExceptionValidation.When(id < 0, "Id invalido");
            Id = id;
            ValidateDomain(nome, descricaoCurta, descricaoDetalhada, preco, estoque, imagemUrl, imagemThumbaiUrl);
        }

        public void Update(string nome, string descricaoCurta, string descricaoDetalhada, decimal preco, int estoque, string imagemUrl, string imagemThumbaiUrl, int categoriaId)
        {
            ValidateDomain(nome, descricaoCurta, descricaoDetalhada, preco, estoque, imagemUrl, imagemThumbaiUrl);
            CategoriaId = categoriaId;
        }


        private void ValidateDomain(string nome, string descricaoCurta, string descricaoDetalhada, decimal preco, int estoque, string imagemUrl, string imagemThumbaiUrl)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "nome invalido. nome é obrigatória");
            DomainExceptionValidation.When(nome.Length < 3, "nome invalido. minimo de 3 caracteres");
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricaoCurta), " descrição invalida. descrição é obrigatória");
            DomainExceptionValidation.When(descricaoCurta.Length < 5, "descrição invalida. minimo de 5 caracteres");
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricaoDetalhada), "descrição detalhada invalida. descriçao é obrigatória");
            DomainExceptionValidation.When(descricaoDetalhada.Length < 10, "descrição detalhada invalida. minimo de 10 caracteres");
            DomainExceptionValidation.When(preco < 0, "preço invalido");
            DomainExceptionValidation.When(estoque < 0, "estoque invalido");
            DomainExceptionValidation.When(imagemUrl?.Length > 250, "imagemUrl invalida. maximo de 250 caracteres");
            DomainExceptionValidation.When(imagemThumbaiUrl?.Length > 250, "ImagemThumbaiUrl invalida. maximo de 250 caracteres");


            Nome = nome;
            DescricaoCurta = descricaoCurta;
            DescricaoDetalhada = descricaoDetalhada;
            Preco = preco;
            Estoque = estoque;
            ImagemUrl = imagemUrl;
            ImagemThumbaiUrl = imagemThumbaiUrl;
        }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
