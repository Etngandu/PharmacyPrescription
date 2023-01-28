using AutoMapper;
using ENB.PharmaciesAndPrescriptions.Entities;
using ENB.PharmaciesAndPrescriptions.MVC.Models;    

namespace ENB.PharmaciesAndPrescriptions.MVC
{
    public class PharmaciesAndPrescriptionsProfile: Profile
    {
        public PharmaciesAndPrescriptionsProfile()
        {
            #region Customer 
            CreateMap<Customer, DisplayCustomer>();

            CreateMap<CreateAndEditCustomer, Customer>()
              .ForMember(d => d.DateCreated, t => t.Ignore())
              .ForMember(d => d.DateModified, t => t.Ignore());
            CreateMap<Customer, CreateAndEditCustomer>();
            #endregion


            #region Physician
            CreateMap<Physician, DisplayPhysician>();

            CreateMap<CreateAndEditPhysician, Physician>()
              .ForMember(d => d.DateCreated, t => t.Ignore())
              .ForMember(d => d.DateModified, t => t.Ignore());
            CreateMap<Physician, CreateAndEditPhysician>();

            #endregion


            #region Prescription
            CreateMap<Prescription, DisplayPrescription>()
             .ForMember(d => d.Customer, t => t.Ignore())
             .ForMember(d => d.Physician, t => t.Ignore())             
             .ForMember(d => d.CustomerId, t => t.MapFrom(y => y.CustomerId));

            CreateMap<CreateAndEditPrescription, Prescription>()
              .ForMember(d => d.CustomerId, t => t.MapFrom(y => y.CustomerId))              
              .ForMember(d => d.Customer, t => t.Ignore())
              .ForMember(d => d.Physician, t => t.Ignore())
              .ForMember(d => d.DateCreated, t => t.Ignore())
              .ForMember(d => d.DateModified, t => t.Ignore())
              .ReverseMap();

            #endregion

            #region PrescriptionItems
            CreateMap<Prescription_item, DisplayPrescriptionItem>()
             .ForMember(d => d.Prescription, t => t.Ignore())
             .ForMember(d => d.Drug_medication, t => t.Ignore())
             .ForMember(d => d.Customer, t => t.Ignore())
             .ForMember(d => d.CustomerId, t => t.MapFrom(y => y.CustomerId))
             .ForMember(d => d.Drug_medicationId, t => t.MapFrom(y => y.Drug_medicationId))
             .ForMember(d => d.PrescriptionId, t => t.MapFrom(y => y.PrescriptionId));

            CreateMap<CreateAndEditPrescriptionItem, Prescription_item>()
              .ForMember(d => d.Drug_medicationId, t => t.MapFrom(y => y.Drug_medicationId))
              .ForMember(d => d.PrescriptionId, t => t.MapFrom(y => y.PrescriptionId))
              .ForMember(d => d.CustomerId, t => t.MapFrom(y => y.CustomerId))
              .ForMember(d => d.Customer, t => t.Ignore())
              .ForMember(d => d.Prescription, t => t.Ignore())
              .ForMember(d => d.Drug_medication, t => t.Ignore())
              .ForMember(d => d.DateCreated, t => t.Ignore())
              .ForMember(d => d.DateModified, t => t.Ignore())
              .ReverseMap();

            #endregion

            #region DrugMedication
            CreateMap<Drug_medication, DisplayDrugAndMedication>()
             .ForMember(d => d.Drug_Company, t => t.Ignore())
             .ForMember(d => d.Drug_companyId, t => t.MapFrom(y => y.Drug_companyId));             

            CreateMap<CreateAndEditDrugAndMedication, Drug_medication>()
              .ForMember(d => d.Drug_companyId, t => t.MapFrom(y => y.Drug_companyId))             
              .ForMember(d => d.DateCreated, t => t.Ignore())
              .ForMember(d => d.DateModified, t => t.Ignore())
              .ForMember(d => d.Drug_Company, t => t.Ignore())
              .ReverseMap();

            #endregion

            #region DrugCompany
            CreateMap<Drug_company, DisplayDrugCompany>();

            CreateMap<CreateAndEditDrugCompany, Drug_company>()
              .ForMember(d => d.DateCreated, t => t.Ignore())
              .ForMember(d => d.DateModified, t => t.Ignore());
            CreateMap<Drug_company, CreateAndEditDrugCompany>();
            #endregion

            #region Address

            CreateMap<Address, EditAddress>()
                  .ForMember(d => d.CustomerId, t => t.Ignore())
                  .ForMember(d => d.PhysicianId, t => t.Ignore())
                  .ForMember(d => d.DrugCompanyId, t => t.Ignore());
            CreateMap<EditAddress, Address>().ConstructUsing(s => new Address(s.Number_street, s.City, s.Zipcode, s.State_province_county, s.Country));
            #endregion

           
        }
    }
}
