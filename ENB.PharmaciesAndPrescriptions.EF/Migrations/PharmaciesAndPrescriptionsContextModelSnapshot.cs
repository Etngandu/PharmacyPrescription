﻿// <auto-generated />
using System;
using ENB.PharmaciesAndPrescriptions.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ENB.PharmaciesAndPrescriptions.EF.Migrations
{
    [DbContext(typeof(PharmaciesAndPrescriptionsContext))]
    partial class PharmaciesAndPrescriptionsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ENB.PharmaciesAndPrescriptions.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Card_expiry_date")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Credit_card_Number")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Other_details")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ENB.PharmaciesAndPrescriptions.Entities.Drug_company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Company_name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ContactPerson")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("MgfLicence")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Other_details")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Drug_Companies");
                });

            modelBuilder.Entity("ENB.PharmaciesAndPrescriptions.Entities.Drug_medication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Drug_Withdrawn_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Drug_available_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Drug_companyId")
                        .HasColumnType("int");

                    b.Property<decimal>("Drug_cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Drug_description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Drug_generic")
                        .HasColumnType("int");

                    b.Property<string>("Drug_name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Generic_equivalent_generic_id")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Other_drug_details")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.HasKey("Id");

                    b.HasIndex("Drug_companyId");

                    b.ToTable("Drug_medication");
                });

            modelBuilder.Entity("ENB.PharmaciesAndPrescriptions.Entities.Physician", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Other_details")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Physicians");
                });

            modelBuilder.Entity("ENB.PharmaciesAndPrescriptions.Entities.Prescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("Payment_Method")
                        .HasColumnType("int");

                    b.Property<int?>("PhysicianId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Presciption_filled_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Presciption_issue_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Prescription_Other_details")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<int>("Prescription_Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PhysicianId");

                    b.ToTable("Prescription");
                });

            modelBuilder.Entity("ENB.PharmaciesAndPrescriptions.Entities.Prescription_item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Drug_medicationId")
                        .HasColumnType("int");

                    b.Property<string>("Instructions_to_customer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrescriptionId")
                        .HasColumnType("int");

                    b.Property<int>("prescription_quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("Drug_medicationId");

                    b.HasIndex("PrescriptionId");

                    b.ToTable("Prescription_item");
                });

            modelBuilder.Entity("ENB.PharmaciesAndPrescriptions.Entities.Customer", b =>
                {
                    b.OwnsOne("ENB.PharmaciesAndPrescriptions.Entities.Address", "AddressCustomer", b1 =>
                        {
                            b1.Property<int>("CustomerId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasDefaultValue("")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasDefaultValue("")
                                .HasColumnName("Country");

                            b1.Property<string>("Number_street")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(600)
                                .HasColumnType("nvarchar(600)")
                                .HasDefaultValue("")
                                .HasColumnName("Numberstreet");

                            b1.Property<string>("State_province_county")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasDefaultValue("")
                                .HasColumnName("State_province_county");

                            b1.Property<string>("Zipcode")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(12)
                                .HasColumnType("nvarchar(12)")
                                .HasDefaultValue("")
                                .HasColumnName("ZipCode");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("AddressCustomer")
                        .IsRequired();
                });

            modelBuilder.Entity("ENB.PharmaciesAndPrescriptions.Entities.Drug_company", b =>
                {
                    b.OwnsOne("ENB.PharmaciesAndPrescriptions.Entities.Address", "DrugCompanyAddress", b1 =>
                        {
                            b1.Property<int>("Drug_companyId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasDefaultValue("")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasDefaultValue("")
                                .HasColumnName("Country");

                            b1.Property<string>("Number_street")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(600)
                                .HasColumnType("nvarchar(600)")
                                .HasDefaultValue("")
                                .HasColumnName("Numberstreet");

                            b1.Property<string>("State_province_county")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasDefaultValue("")
                                .HasColumnName("State_province_county");

                            b1.Property<string>("Zipcode")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(12)
                                .HasColumnType("nvarchar(12)")
                                .HasDefaultValue("")
                                .HasColumnName("ZipCode");

                            b1.HasKey("Drug_companyId");

                            b1.ToTable("Drug_Companies");

                            b1.WithOwner()
                                .HasForeignKey("Drug_companyId");
                        });

                    b.Navigation("DrugCompanyAddress")
                        .IsRequired();
                });

            modelBuilder.Entity("ENB.PharmaciesAndPrescriptions.Entities.Drug_medication", b =>
                {
                    b.HasOne("ENB.PharmaciesAndPrescriptions.Entities.Drug_company", "Drug_Company")
                        .WithMany("Drug_Medications")
                        .HasForeignKey("Drug_companyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drug_Company");
                });

            modelBuilder.Entity("ENB.PharmaciesAndPrescriptions.Entities.Physician", b =>
                {
                    b.OwnsOne("ENB.PharmaciesAndPrescriptions.Entities.Address", "AddressPhysician", b1 =>
                        {
                            b1.Property<int>("PhysicianId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasDefaultValue("")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasDefaultValue("")
                                .HasColumnName("Country");

                            b1.Property<string>("Number_street")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(600)
                                .HasColumnType("nvarchar(600)")
                                .HasDefaultValue("")
                                .HasColumnName("Numberstreet");

                            b1.Property<string>("State_province_county")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasDefaultValue("")
                                .HasColumnName("State_province_county");

                            b1.Property<string>("Zipcode")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(12)
                                .HasColumnType("nvarchar(12)")
                                .HasDefaultValue("")
                                .HasColumnName("ZipCode");

                            b1.HasKey("PhysicianId");

                            b1.ToTable("Physicians");

                            b1.WithOwner()
                                .HasForeignKey("PhysicianId");
                        });

                    b.Navigation("AddressPhysician")
                        .IsRequired();
                });

            modelBuilder.Entity("ENB.PharmaciesAndPrescriptions.Entities.Prescription", b =>
                {
                    b.HasOne("ENB.PharmaciesAndPrescriptions.Entities.Customer", "Customer")
                        .WithMany("Prescriptions")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ENB.PharmaciesAndPrescriptions.Entities.Physician", "Physician")
                        .WithMany("Prescriptions")
                        .HasForeignKey("PhysicianId");

                    b.Navigation("Customer");

                    b.Navigation("Physician");
                });

            modelBuilder.Entity("ENB.PharmaciesAndPrescriptions.Entities.Prescription_item", b =>
                {
                    b.HasOne("ENB.PharmaciesAndPrescriptions.Entities.Customer", "Customer")
                        .WithMany("Prescription_Items")
                        .HasForeignKey("CustomerId");

                    b.HasOne("ENB.PharmaciesAndPrescriptions.Entities.Drug_medication", "Drug_medication")
                        .WithMany("Prescription_Items")
                        .HasForeignKey("Drug_medicationId");

                    b.HasOne("ENB.PharmaciesAndPrescriptions.Entities.Prescription", "Prescription")
                        .WithMany("Prescription_Items")
                        .HasForeignKey("PrescriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Drug_medication");

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("ENB.PharmaciesAndPrescriptions.Entities.Customer", b =>
                {
                    b.Navigation("Prescription_Items");

                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("ENB.PharmaciesAndPrescriptions.Entities.Drug_company", b =>
                {
                    b.Navigation("Drug_Medications");
                });

            modelBuilder.Entity("ENB.PharmaciesAndPrescriptions.Entities.Drug_medication", b =>
                {
                    b.Navigation("Prescription_Items");
                });

            modelBuilder.Entity("ENB.PharmaciesAndPrescriptions.Entities.Physician", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("ENB.PharmaciesAndPrescriptions.Entities.Prescription", b =>
                {
                    b.Navigation("Prescription_Items");
                });
#pragma warning restore 612, 618
        }
    }
}
