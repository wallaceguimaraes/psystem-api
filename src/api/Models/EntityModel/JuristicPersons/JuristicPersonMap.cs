using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Models.EntityModel.JuristicPersons
{
    public static class JuristicPersonMap
    {
        public static void Map(this EntityTypeBuilder<JuristicPerson> entity)
        {
            entity.ToTable("PessoaJuridica", "cadastro");

            entity.HasKey(p => p.PersonId);

            entity.Property(p => p.PersonId).HasColumnName("IdPessoa");
            entity.Property(p => p.BusinessTypeId).HasColumnName("IdTipoEmpresa").IsRequired();
            entity.Property(p => p.TradeName).HasColumnName("NomeFantasia").HasMaxLength(120).IsRequired();
            entity.Property(p => p.FullName).HasColumnName("RazaoSocial").HasMaxLength(120).IsRequired();
            entity.Property(p => p.TaxDocument).HasColumnName("Cnpj").HasMaxLength(18).IsRequired();
            entity.Property(p => p.CnaeCode).HasColumnName("CodigoCnae").HasMaxLength(15);

            entity.HasOne(p => p.Cnae).WithMany(x => x.JuristicPeople).HasForeignKey(x => x.CnaeCode).OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(p => p.TaxDocument);
        }
    }
}