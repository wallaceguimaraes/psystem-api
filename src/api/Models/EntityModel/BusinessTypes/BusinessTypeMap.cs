using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Models.EntityModel.BusinessTypes
{
    public static class BusinessTypeMap
    {
        public static void Map(this EntityTypeBuilder<BusinessType> entity)
        {
            entity.ToTable("TipoEmpresa", "cadastro");

            entity.HasKey(p => p.Id);
            // entity.Property(p => p.Id).ValueGeneratedOnAdd().UseMySqlIdentityColumn();
            entity.Property(p => p.Id).HasColumnName("Id").UseIdentityColumn();
            entity.Property(p => p.Name).HasColumnName("Nome").HasMaxLength(80).IsRequired();
            entity.Property(p => p.Acronym).HasColumnName("Sigla").HasMaxLength(10).IsRequired();

            entity.HasMany(p => p.JuristicPersons).WithOne(p => p.BusinessType).HasForeignKey(p => p.BusinessTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}