using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ENB.PharmaciesAndPrescriptions.Infrastructure;
using ENB.PharmaciesAndPrescriptions.Entities;

namespace ENB.PharmaciesAndPrescriptions.EF.ConfigurationEntity
{
   public class DrugCompanyConfiguration:IEntityTypeConfiguration<Drug_company>
    {
        public void Configure(EntityTypeBuilder<Drug_company> builder)
        {
            builder.Property(x => x.Company_name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.EmailAddress).IsRequired().HasMaxLength(250);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(150);
            builder.Property(x => x.ContactPerson).IsRequired().HasMaxLength(250);
            builder.Property(x => x.MgfLicence).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Other_details).IsRequired().HasMaxLength(450);
            builder.OwnsOne(o => o.DrugCompanyAddress, a =>
            {
                a.Property(p => p.Number_street).HasMaxLength(600)
                    .HasColumnName("Numberstreet")
                    .HasDefaultValue("");
                a.Property(p => p.City).HasMaxLength(250)
                    .HasColumnName("City")
                    .HasDefaultValue("");
                a.Property(p => p.State_province_county).HasMaxLength(250)
                    .HasColumnName("State_province_county")
                    .HasDefaultValue("");
                a.Property(p => p.Zipcode).HasMaxLength(12)
                    .HasColumnName("ZipCode")
                    .HasDefaultValue("");
                a.Property(p => p.Country).HasMaxLength(250)
                   .HasColumnName("Country")
                   .HasDefaultValue("");
            });
        }
    }
}
