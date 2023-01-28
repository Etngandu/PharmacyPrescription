using ENB.PharmaciesAndPrescriptions.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENB.ApartmentRentals.EF.ConfigurationEntity
{
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.Property(x => x.Prescription_Other_details).IsRequired().HasMaxLength(350);
            

        }
    }
}
