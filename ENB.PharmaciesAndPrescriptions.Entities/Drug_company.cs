using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENB.PharmaciesAndPrescriptions.Entities.Collections;
using ENB.PharmaciesAndPrescriptions.Infrastructure;

namespace ENB.PharmaciesAndPrescriptions.Entities
{
    public class Drug_company : DomainEntity<int>, IDateTracking
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Physician class.
        /// </summary>
       
        public Drug_company()
        {

            Drug_Medications = new Drug_medications();
            DrugCompanyAddress = new Address();
           
        }


        #endregion
        #region "Public Properties"

        /// <summary>
        /// Gets or sets the  name of this Drug_company.
        /// </summary>
        [Required]
        public string Company_name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the  MgfLicence of this Drug_company.
        /// </summary>

        public string MgfLicence { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the  EmailAddress of this Drug_company.
        /// </summary>

        public string EmailAddress { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the  PhoneNumbre of this Drug_company.
        /// </summary>

        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the  Contactperson of this Drug_company.
        /// </summary>

        public string ContactPerson { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the  Address of this Drug_company.
        /// </summary>

        public Address DrugCompanyAddress { get; set; } 


        /// <summary>
        /// Gets or sets the Other_details of the Customer.
        /// </summary>
        /// 
        public string Other_details { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Drug_Medications of this Drug_company.
        /// </summary>
        /// 
        public Drug_medications Drug_Medications { get; set; }

        /// <summary>
        /// Gets or sets the date and time the object was last modified.
        /// </summary>
        public DateTime DateCreated { get ; set ; }

        /// <summary>
        /// Gets or sets the date and time the object was last modified.
        /// </summary>
        /// 
        public DateTime DateModified { get ; set ; }
        #endregion
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(MgfLicence))
            {
                yield return new ValidationResult("MgfLicence can't be None.", new[] { "MgfLicence" });

            }
        }
    }
}
