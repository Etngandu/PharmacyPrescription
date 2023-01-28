using ENB.PharmaciesAndPrescriptions.Entities;
using ENB.PharmaciesAndPrescriptions.Entities.Collections;
using ENB.PharmaciesAndPrescriptions.MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace ENB.PharmaciesAndPrescriptions.MVC.Models
{
    public class CreateAndEditDrugCompany: IValidatableObject
    {
        #region "Public Properties"


        public int Id { get; set; }

        [Required]
        public string Company_name { get; set; } = string.Empty;


        public string MgfLicence { get; set; } = string.Empty;

        [EmailAddress] 
        public string EmailAddress { get; set; } = string.Empty;

        //[Phone]
        public string PhoneNumber { get; set; } = string.Empty;


        public string ContactPerson { get; set; } = string.Empty;

        public string Other_details { get; set; } = string.Empty;
        #endregion
        #region validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
             if(string.IsNullOrEmpty(MgfLicence)) { 
              yield return new ValidationResult ("MgfLicence can't be None.", new[] { "MgfLicence" });
            }

            if (string.IsNullOrEmpty(ContactPerson))
            {
                yield return new ValidationResult("ContactPerson can't be None.", new[] { "ContactPerson" });
            }
        }
        #endregion
    }
}
