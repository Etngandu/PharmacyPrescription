using ENB.PharmaciesAndPrescriptions.Entities;
using ENB.PharmaciesAndPrescriptions.Entities.Collections;
using ENB.PharmaciesAndPrescriptions.MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace ENB.PharmaciesAndPrescriptions.MVC.Models
{
    public class CreateAndEditPhysician: IValidatableObject
    {
        #region "Public Properties"

        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;


        public string LastName { get; set; } = string.Empty;

        public string EmailAddress { get; set; } = string.Empty;

        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;

        public DateTime DateOfBirth
        {
            get;
            set;
        }

        

        public string Other_details { get; set; } = string.Empty;   
       

        public Prescriptions? Prescriptions { get; set; }
        #endregion

        #region validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Gender==Gender.None)
            {
                yield return new ValidationResult("Gender can't be None.", new[] { "Gender" });
            }
            if (String.IsNullOrEmpty(PhoneNumber))
            {
                yield return new ValidationResult("PhoneNumber can't be None.", new[] { "PhoneNumber" });
            }

            if (String.IsNullOrEmpty(EmailAddress))
            {
                yield return new ValidationResult("EmailAddress can't be None.", new[] { "EmailAddress" });
            }
        }
        #endregion
    }
}
