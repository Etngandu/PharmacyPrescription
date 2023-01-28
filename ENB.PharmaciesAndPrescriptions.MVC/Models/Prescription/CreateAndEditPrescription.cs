using ENB.PharmaciesAndPrescriptions.Entities;
using ENB.PharmaciesAndPrescriptions.Entities.Collections;
using ENB.PharmaciesAndPrescriptions.MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ENB.PharmaciesAndPrescriptions.MVC.Models
{
    public class CreateAndEditPrescription :IValidatableObject
    {
        #region "Public Properties"

        public int Id { get; set; }
        public Customer? Customer { get; set; }

        public int CustomerId { get; set; }


        public Physician? Physician { get; set; }

        public int PhysicianId { get; set; }

        public List<SelectListItem>? ListPhysicians { get; set; }

        public List<SelectListItem>? ListCustomers { get; set; }

        public Ref_Prescription_status Prescription_Status { get; set; }

        public string Prescription_Other_details { get; set; } = string.Empty;
        public Ref_payment_method Payment_Method { get; set; }


        [Display(Name = "Presciption issue date")]
        public DateTime Presciption_issue_date { get; set; } = DateTime.Now;


        [Display(Name = "Presciption filled date")]
        public DateTime Presciption_filled_date { get; set; } = DateTime.Now;  

        public DateTime DateCreated { get; set; }


        public DateTime DateModified { get; set; }
        #endregion

        #region validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Prescription_Status==Ref_Prescription_status.None)
            {
                yield return new ValidationResult("Prescription_Status can't be None.", new[] { "Prescription_Status" });
            }

            if (Payment_Method==Ref_payment_method.None)
            {
                yield return new ValidationResult("Payment_Method can't be None.", new[] { "Payment_Method" });
            }
        }
        #endregion
    }
}
