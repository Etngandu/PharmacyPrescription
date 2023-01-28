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
    public class Customer : DomainEntity<int>, IDateTracking
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Customer class.
        /// </summary>
        public Customer()
        {
            Prescriptions = new Prescriptions();
            AddressCustomer = new Address();
            Prescription_Items = new Prescription_Items();
             
        }
       
        #endregion

        #region "Public Properties"

        /// <summary>
        /// Gets or sets the first name of this Customer.
        /// </summary>
        [Required]
        public string FirstName { get; set; }=String.Empty;

        /// <summary>
        /// Gets or sets the last name of this Customer.
        /// </summary>
        [Required]
        public string LastName { get; set; }= String.Empty;

        /// <summary>
        /// Gets or sets the EmailAddress of the Customer.
        /// </summary>
        /// 
        public string EmailAddress { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the Gender of the Customer.
        /// </summary>
        /// 
        public Gender Gender { get; set; } 

        /// <summary>
        /// Gets or sets the PhoneNumber of the Customer.
        /// </summary>
        /// 
        public string PhoneNumber { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the DateOfBirth of the Customer.
        /// </summary>
        /// 
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Prescription_Items of this prescription.
        /// </summary>
        /// 

        public Prescription_Items Prescription_Items { get; set; }

        /// <summary>
        /// Gets or sets the Credit_card_Number of the Customer.
        /// </summary>
        /// 
        public string Credit_card_Number { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the Card_expiry_date of the Customer.
        /// </summary>
        /// 
        public string Card_expiry_date { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the Other_details of the Customer.
        /// </summary>
        /// 
        public string Other_details { get; set; } = String.Empty;

        /// <summary>
        /// Gets the full name of this person.
        /// </summary>
        public string FullName
        {
            get
            {
                string temp = FirstName ?? string.Empty;
                if (!string.IsNullOrEmpty(LastName))
                {
                    if (temp.Length > 0)
                    {
                        temp += " ";
                    }
                    temp += LastName;
                }
                return temp;
            }
        }

        /// <summary>
        /// Gets or sets the Prescriptions of this customer.
        /// </summary>

        public Prescriptions Prescriptions { get; set; }

        /// <summary>
        /// Gets or sets the Address of this customer.
        /// </summary>

        public Address AddressCustomer { get; set; }

        /// <summary>
        /// Gets or sets the date and time the object was last modified.
        /// </summary>
        public DateTime DateCreated { get ; set ; }

        /// <summary>
        /// Gets or sets the date and time the object was last modified.
        /// </summary>
        /// 
        public DateTime DateModified { get; set ; }
        #endregion



        #region Methods

        /// <summary>
        /// Validates this object. It validates dependencies between properties and also calls Validate on child collections;
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns>A IEnumerable of ValidationResult. The IEnumerable is empty when the object is in a valid state.</returns>
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateOfBirth < DateTime.Now.AddYears(Constants.MaxAgePerson * -1))
            {
                yield return new ValidationResult("Invalid range for DateOfBirth; must be between today and 130 years ago.", new[] { "DateOfBirth" });
            }
            if (DateOfBirth > DateTime.Now)
            {
                yield return new ValidationResult("Invalid range for DateOfBirth; must be between today and 130 years ago.", new[] { "DateOfBirth" });
            }
        }
        #endregion
    }
}
