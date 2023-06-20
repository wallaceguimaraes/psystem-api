using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Models.EntityModel.Companies
{
    public static class CompanyMap
    {
        public static void Map(this EntityTypeBuilder<Company> entity)
        {
            entity.ToTable("Empresa", "cadastro");
            entity.HasKey(p => p.Id);
            // entity.Property(p => p.Id).ValueGeneratedOnAdd().UseMySqlIdentityColumn();
            entity.Property(p => p.Id).HasColumnName("Id").UseIdentityColumn();

            entity.Property(p => p.BusinessTypeAcronym).HasColumnName("SiglaTipoNegocio").IsRequired();
            entity.Property(p => p.BusinessTypeName).HasColumnName("TipoNegocio").IsRequired();
            entity.Property(p => p.TradeName).HasColumnName("NomeFantasia").HasMaxLength(120).IsRequired();
            entity.Property(p => p.FullName).HasColumnName("RazaoSocial").HasMaxLength(120).IsRequired();
            entity.Property(p => p.TaxDocument).HasColumnName("Cnpj").HasMaxLength(18).IsRequired();
            entity.Property(p => p.CnaeCode).HasColumnName("CodigoCnae").HasMaxLength(15);
            entity.Property(p => p.SystemImplementation).HasColumnName("ImplementacaoSistema");
        }
    }
}