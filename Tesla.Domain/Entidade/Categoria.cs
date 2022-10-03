using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Domain.Validacao;

namespace Tesla.Domain.Entidade
{
    public sealed class Categoria : EntidadeBase
    {
        //public int Id { get; private set; }
        public string Nome { get; private set; }

        public Categoria(string nome)
        {
            ValidateDomain(nome);
        }

        public Categoria(int id, string nome)
        {
            DomainExceptionValidation.When(id < 0, "id invalido");
            Id = id;
            ValidateDomain(nome);
        }

        public ICollection<Produto> Produtos { get; set; }


        private void ValidateDomain(string nome)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "nome invalido. Nome é obrigatório");

            DomainExceptionValidation.When(nome.Length < 3, "nome invalido. minimo 3 caracteres");

            Nome = nome;
        }
    }
}
