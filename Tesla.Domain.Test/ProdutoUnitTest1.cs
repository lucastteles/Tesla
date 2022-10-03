using FluentAssertions;
using System;
using Tesla.Domain.Entidade;
using Xunit;

namespace Tesla.Domain.Test
{
    public class ProdutoUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Produto(1, "Produto Nome", "Produto DescricaoCurta", "Produto DescricaoDetalhada", 9.99m, 99, "produto imagemUrl", "produto imageThumbaiUrl");
            action.Should()
                .NotThrow<Tesla.Domain.Validacao.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Produto(-1, "Produto Nome", "Produto DescricaoCurta", "Produto DescricaoDetalhada", 9.99m, 99, "produto imagemUrl", "produto imageThumbaiUrl");
            action.Should()
                .Throw<Tesla.Domain.Validacao.DomainExceptionValidation>()
                .WithMessage("Id invalido");
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Produto(1, "Produto Nome", "Produto DescricaoCurta", "Produto DescricaoDetalhada", 9.99m, 99, "product imageUrl gggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggghhhhhhhhhhhhhhhhhhhhhhhhhhhhggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggfffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffgggggggggg", "produto imageThumbaiUrl");
            action.Should()
                .Throw<Tesla.Domain.Validacao.DomainExceptionValidation>()
                .WithMessage("imagemUrl invalida. maximo de 250 caracteres");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Produto(1, "Pr", "Produto DescricaoCurta", "Produto DescricaoDetalhada", 9.99m, 99, "produto imagemUrl", "produto imageThumbaiUrl");
            action.Should()
                .Throw<Tesla.Domain.Validacao.DomainExceptionValidation>()
                .WithMessage("nome invalido. minimo de 3 caracteres");
        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            Action action = () => new Produto(1, "Produto Nome", "Produto DescricaoCurta", "Produto DescricaoDetalhada", 9.99m, 99, "produto imagemUrl", "");
            action.Should()
                .NotThrow<Tesla.Domain.Validacao.DomainExceptionValidation>();

        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Produto(1, "Produto Nome", "Produto DescricaoCurta", "Produto DescricaoDetalhada", 9.99m, 99, "produto imagemUrl", null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }

        [Fact]
        public void CreateProduct_WithNullImageName_DomainException()
        {
            Action action = () => new Produto(1, "Produto Nome", "Produto DescricaoCurta", "Produto DescricaoDetalhada", 9.99m, 99, "produto imagemUrl", null);
            action.Should()
                .NotThrow<Tesla.Domain.Validacao.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_InvalidPriceValue_DomainException()
        {
            Action action = () => new Produto(1, "Produto Nome", "Produto DescricaoCurta", "Produto DescricaoDetalhada", -9.99m, 99, "produto imagemUrl", null);
            action.Should()
                .Throw<Tesla.Domain.Validacao.DomainExceptionValidation>()
                .WithMessage("preço invalido");
        }

        [Theory]//Quando se tem parametro no teste de unidade
        [InlineData(-5)]// = value
        public void CreateProduct_WithInvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Produto(1, "Pro", "Produto DescricaoCurta", "Produto DescricaoDetalhada", 9.99m, value, "produto imagemUrl", null);
            action.Should()
                .Throw<Tesla.Domain.Validacao.DomainExceptionValidation>()
                .WithMessage("estoque invalido");
        }
    }
}
