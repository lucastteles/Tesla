using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Domain.Entidade;

namespace Tesla.Repo.Mapping
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(t => t.Id);

            builder.Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.DescricaoDetalhada)
                .HasColumnName("DescricaoDetalhada")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.DescricaoCurta)
               .HasColumnName("DescricaoCurta")
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(p => p.Preco)
                .HasColumnName("Preco")
                .HasPrecision(10, 2);

            builder.HasOne(e => e.Categoria).WithMany(e => e.Produtos)
                .HasForeignKey(e => e.CategoriaId);
        }

        
    }
}
