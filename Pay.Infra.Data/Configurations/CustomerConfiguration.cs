using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pay.Domain.Moldes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pay.Infra.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(255);
            builder.Property(c => c.CPF).IsRequired().HasMaxLength(14);
            builder.HasIndex(c => c.CPF).IsUnique();
            builder.Property(c => c.ValorLimite).IsRequired().HasColumnType("decimal(18,2)");
        }
    }
}
