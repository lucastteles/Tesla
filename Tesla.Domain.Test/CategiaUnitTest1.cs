using FluentAssertions;
using System;
using Tesla.Domain.Entidade;
using Xunit;

namespace Tesla.Domain.Test
{
    public class CategiaUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Categoria(1, "Category Name");
            action.Should()
                .NotThrow<Tesla.Domain.Validacao.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Categoria(-1, "Category Name");
            action.Should()
                .Throw<Tesla.Domain.Validacao.DomainExceptionValidation>()
                .WithMessage("id invalido");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Categoria(1, "Ca");
            action.Should()
                .Throw<Tesla.Domain.Validacao.DomainExceptionValidation>()
                .WithMessage("nome invalido. minimo 3 caracteres");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Categoria(1, "");
            action.Should()
                .Throw<Tesla.Domain.Validacao.DomainExceptionValidation>()
                .WithMessage("nome invalido. Nome é obrigatório");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Categoria(1, null);
            action.Should()
                .Throw<Tesla.Domain.Validacao.DomainExceptionValidation>();

        }
    }
}
