using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENB.PharmaciesAndPrescriptions.Entities.Collections
{
    
    //// <summary>
    ///// Represents a collection of PhoneNumber instances in the system.
    ///// </summary>
    public class Prescriptions : CollectionBase<Prescription>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumbers"/> class.
        /// </summary>
        public Prescriptions() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumbers"/> class.
        /// </summary>
        /// <param name="initialList">Accepts an IList of PhoneNumber as the initial list.</param>
        public Prescriptions(IList<Prescription> initialList) : base(initialList) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumbers"/> class.
        /// </summary>
        /// <param name="initialList">Accepts a CollectionBase of PhoneNumber as the initial list.</param>
        public Prescriptions(CollectionBase<Prescription> initialList) : base(initialList) { }

        /// <summary>
        /// Adds a new instance of PhoneNumber to the collection.
        /// </summary>
        /// <param name="number">The e-phone number text.</param>
        /// <param name="contactType">The type of the phone number.</param>
        public void Add( Ref_payment_method ref_Payment_Method)
        {
            Add(new Prescription() { Payment_Method = ref_Payment_Method });
        }

        /// <summary>
        /// Validates the current collection by validating each individual item in the collection.
        /// </summary>
        /// <returns>A IEnumerable of ValidationResult. The IEnumerable is empty when the object is in a valid state.</returns>
        public IEnumerable<ValidationResult> Validate()
        {
            var errors = new List<ValidationResult>();
            foreach (var number in this)
            {
                errors.AddRange(number.Validate());
            }
            return errors;
        }
    }
}
