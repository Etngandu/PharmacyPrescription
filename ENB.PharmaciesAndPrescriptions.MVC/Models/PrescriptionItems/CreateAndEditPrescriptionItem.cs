using ENB.PharmaciesAndPrescriptions.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ENB.PharmaciesAndPrescriptions.MVC.Models
{
    public class CreateAndEditPrescriptionItem: IValidatableObject
    {
        public int Id { get; set; }
        public Prescription? Prescription { get; set; }

        public int PrescriptionId { get; set; }

        public Drug_medication? Drug_medication { get; set; }

        public int Drug_medicationId { get; set; }

        public Customer? Customer { get; set; }

        public int CustomerId { get; set; }

        public int prescription_quantity { get; set; }

        public string Instructions_to_customer { get; set; } = String.Empty;

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public List<SelectListItem>? ListDrugs { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Instructions_to_customer))
            {
                yield return new ValidationResult("Instructions to customer can't be None.", new[] { "Instructions_to_customer" });
            }
        }
    }
}
