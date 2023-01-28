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
    public class Drug_medication : DomainEntity<int>, IDateTracking
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Physician class.
        /// </summary>
        public Drug_medication()
        {

            Prescription_Items = new Prescription_Items();
           
        }

        #endregion
        #region "Public Properties"


        /// <summary>
        /// Gets or sets the  name of this Drug_company.
        /// </summary>
        public string Drug_name { get; set; }=String.Empty;

        /// <summary>
        /// Gets or sets the  name of this Drug_company.
        /// </summary>
      
        public Drug_company? Drug_Company { get; set; }

        /// <summary>
        /// Gets or sets the  name of this Drug_companyId.
        /// </summary>
        public int Drug_companyId { get; set; }
        
        /// <summary>
        /// Gets or sets the  cost of this Drug.
        /// </summary>
        public decimal Drug_cost { get; set; }

        /// <summary>
        /// Gets or sets the  available date of this Drug.
        /// </summary>
        public DateTime Drug_available_date { get; set; }

        /// <summary>
        /// Gets or sets the  Withdrawn_date of this Drug.
        /// </summary>
        public DateTime Drug_Withdrawn_date { get; set; }

        /// <summary>
        /// Gets or sets the  description of this Drug.
        /// </summary>
        public string Drug_description { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the status of this Drug.
        /// </summary>
        public Drug_generic Drug_generic { get; set; }

        /// <summary>
        /// Gets or sets the  equivalent_generic_id of this Drug.
        /// </summary>
        public string Generic_equivalent_generic_id { get; set; }= String.Empty;

        /// <summary>
        /// Gets or sets the  drug_details of this Drug.
        /// </summary>
        public string Other_drug_details { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the  Prescription_Items of this Drug.
        /// </summary>
        public Prescription_Items Prescription_Items { get; set; }

        /// <summary>
        /// Gets or sets the date and time the object was last created.
        /// </summary>
        public DateTime DateCreated { get ; set ; }
        /// <summary>
        /// Gets or sets the date and time the object was last modified.
        /// </summary>
        public DateTime DateModified { get ; set ; }
        #endregion

        #region Methods

        /// <summary>
        /// Validates this object. It validates dependencies between properties and also calls Validate on child collections;
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns>A IEnumerable of ValidationResult. The IEnumerable is empty when the object is in a valid state.</returns>
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Drug_generic == Drug_generic.None)
            {
                yield return new ValidationResult("Drug_generic_Status can't be None.", new[] { "Prescription_Status" });
            }           
            if (Drug_available_date < DateTime.Now)
            {
                yield return new ValidationResult("Invalid range for Drug_available_date; must be available from today .", new[] { "Drug_available_date" });
            }
        }
        #endregion
    }
}
