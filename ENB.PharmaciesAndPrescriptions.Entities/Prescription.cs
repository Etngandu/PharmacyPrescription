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
    public class Prescription : DomainEntity<int>, IDateTracking
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Customer class.
        /// </summary>
        public Prescription()
        {

            Prescription_Items = new Prescription_Items();            
        }

        #endregion
        #region "Public Properties"
        /// <summary>
        /// Gets or sets the navigation property of the Customer.
        /// </summary>
        /// 
        
        public Customer? Customer { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Customer.
        /// </summary>
        /// 
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property of the physician.
        /// </summary>
        ///        
        public Physician? Physician { get; set; }

        /// <summary>
        /// Gets or sets the Id of the physician.
        /// </summary>
        /// 
        public int? PhysicianId { get; set; }

        /// <summary>
        /// Gets or sets the Prescription status.
        /// </summary>
        /// 
        public Ref_Prescription_status Prescription_Status { get; set; }

        /// <summary>
        /// Gets or sets the Payment_Method.
        /// </summary>
        /// 
        public Ref_payment_method Payment_Method { get; set; }

        /// <summary>
        /// Gets or sets the Presciption_issue_date.
        /// </summary>
        /// 
        [Display(Name = "Presciption issue date")]
        public DateTime Presciption_issue_date { get; set; }

        /// <summary>
        /// Gets or sets the Presciption_filled_date.
        /// </summary>
        /// 
        [Display(Name = "Presciption filled date")]
        public DateTime Presciption_filled_date { get; set; }

        /// <summary>
        /// Gets or sets the Prescription_Items of this prescription.
        /// </summary>
        /// 

        public Prescription_Items Prescription_Items { get; set; }

        public string Prescription_Other_details { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date and time the object was last created.
        /// </summary>
        public DateTime DateCreated { get ; set ; }

        /// <summary>
        /// Gets or sets the date and time the object was last modified.
        /// </summary>
        /// 
        public DateTime DateModified { get ; set ; }

        /// <summary>
        /// Gets the full name of this person.
        /// </summary>
        public string PrescriptionNumber
        {
            get
            {
                string temp = DateCreated.ToShortDateString() ?? string.Empty;
                if (!string.IsNullOrEmpty(PhysicianId.ToString()) &&
                    !string.IsNullOrEmpty(CustomerId.ToString()))
                {

                    if (temp.Length > 0)
                    {
                        temp += "-";
                    }
                    temp += PhysicianId.ToString() + "/" +CustomerId.ToString();
                }
                return temp;
            }
        }
        #endregion

        #region "Methods"
        /// <summary>
        /// Validates this object. It validates dependencies between properties and also calls Validate on child collections;
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns>A IEnumerable of ValidationResult. The IEnumerable is empty when the object is in a valid state.</returns>
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Prescription_Status == Ref_Prescription_status.None)
            {
                yield return new ValidationResult("Prescription_Status can't be None.", new[] { "Prescription_Status" });
            }
            if (Payment_Method == Ref_payment_method.None)
            {
                yield return new ValidationResult("Payment_Method can't be None.", new[] { "Payment_Method" });
            }

            
        }
        #endregion
    }
}
