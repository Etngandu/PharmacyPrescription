using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ENB.PharmaciesAndPrescriptions.Infrastructure;
using ENB.PharmaciesAndPrescriptions.Entities;

namespace LawyerOffice.Data.EF.ConfigurationEntity
{
   public class DrugAndMedicationConfiguration:IEntityTypeConfiguration<Drug_medication>
    {
        public void Configure(EntityTypeBuilder<Drug_medication> builder)
        {
            builder.Property(x => x.Drug_description).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Drug_name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Generic_equivalent_generic_id).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Other_drug_details).IsRequired().HasMaxLength(350);            
                   
        }
    }
}
