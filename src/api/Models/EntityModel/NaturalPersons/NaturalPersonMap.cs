using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Models.EntityModel.NaturalPersons
{
    public static class NaturalPersonMap
    {
        public static void Map(this EntityTypeBuilder<NaturalPerson> entity)
        {
            entity.ToTable("PessoaFisica", "cadastro");

            entity.HasKey(p => p.PersonId);

            entity.Property(p => p.PersonId).HasColumnName("IdPessoa");
            entity.Property(p => p.FullName).HasColumnName("Nome").HasMaxLength(155).IsRequired();
            entity.Property(p => p.BirthDate).HasColumnName("DataNascimento").HasColumnType("date");
            entity.Property(p => p.Gender).HasColumnName("Genero").HasMaxLength(1);
            entity.Property(p => p.TaxDocument).HasColumnName("Cpf").HasMaxLength(24);

            entity.HasIndex(p => p.TaxDocument);
        }
    }
}