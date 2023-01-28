using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ENB.PharmaciesAndPrescriptions.Infrastructure;

namespace ENB.PharmaciesAndPrescriptions.Entities
{
    public class Prescription_item:DomainEntity<int>,IDateTracking
    {
       
        
        #region "Public Properties"


        /// <summary>
        /// Gets or sets the navigation property prescription.
        /// </summary>
       
        public Prescription? Prescription  { get; set; }

        /// <summary>
        /// Gets or sets the Id property prescription.
        /// </summary>
        public int PrescriptionId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property drug_medication .
        /// </summary>
        public Drug_medication? Drug_medication { get; set; }

        /// <summary>
        /// Gets or sets the Id property drug_medication.
        /// </summary>
        public int? Drug_medicationId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property Customer.
        /// </summary>

        public Customer? Customer { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Customer.
        /// </summary>
        /// 
        public int? CustomerId { get; set; }


        /// <summary>
        /// Gets or sets the prescription_quantity.
        /// </summary>
        public int prescription_quantity { get; set; }

        /// <summary>
        /// Gets or sets the Instructions_to_customer.
        /// </summary>
        public string Instructions_to_customer { get; set; }=String.Empty;

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
            if(string.IsNullOrEmpty(Instructions_to_customer))
            {
               yield return new ValidationResult("Instructions to customer can't be None.", new[] { "Instructions_to_customer" });
            }
        
        }
        #endregion
    }
}
