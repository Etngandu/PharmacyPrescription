using ENB.PharmaciesAndPrescriptions.Entities.Collections;
using ENB.PharmaciesAndPrescriptions.Entities;
using System.ComponentModel.DataAnnotations;

namespace ENB.PharmaciesAndPrescriptions.MVC.Models
{
    public class CreateAndEditDrugAndMedication : IValidatableObject
    {
        public int Id { get; set; }
        public string Drug_name { get; set; } = String.Empty;
        public Drug_company? Drug_Company { get; set; }
        public int Drug_companyId { get; set; }
        public decimal Drug_cost { get; set; }
        public DateTime Drug_available_date { get; set; }
        public DateTime Drug_Withdrawn_date { get; set; }
        public string Drug_description { get; set; } = String.Empty;
        public Drug_generic Drug_generic { get; set; }
        public string Generic_equivalent_generic_id { get; set; } = String.Empty;
        public string Other_drug_details { get; set; } = String.Empty;
        public Prescription_Items? Prescription_Items { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Drug_generic==Drug_generic.None)
            {
                yield return new ValidationResult("Drug_generic can't be None", new[] { "Drug_generic" });
            }
        }
    }
}
