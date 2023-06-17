using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Models.EntityModel.Addresses
{
    public static class AddressMap
    {
        public static void Map(this EntityTypeBuilder<Address> entity)
        {
            entity.ToTable("Endereco", "cadastro");

            entity.HasKey(p => p.PersonId);

            entity.Property(p => p.District).HasColumnName("Bairro").HasMaxLength(50).IsRequired();
            entity.Property(p => p.Line1).HasColumnName("Endereco").HasMaxLength(150).IsRequired();
            entity.Property(p => p.Line2).HasColumnName("Complemento").HasMaxLength(80);
            entity.Property(p => p.StreetNumber).HasColumnName("Numero").HasMaxLength(20);
            entity.Property(p => p.ZipCode).HasColumnName("Cep").HasMaxLength(9).IsRequired();
            entity.Property(p => p.CityId).HasColumnName("IdCidade").IsRequired();
            entity.Property(p => p.City).HasColumnName("Cidade").IsRequired();
            entity.Property(p => p.PersonId).HasColumnName("IdPessoa").IsRequired();
        }
    }
}