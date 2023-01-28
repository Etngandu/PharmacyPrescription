using System.ComponentModel.DataAnnotations;

namespace ENB.PharmaciesAndPrescriptions.Entities
{
    /// <summary>
    /// Determines the type of a contact person.
    /// </summary>
    public enum Ref_Prescription_status
    {
        /// <summary>
        /// Indicates an unidentified value.
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates a Divorce Lawyer.
        /// </summary>
        Filled = 1,

        [Display(Name = "Part Filled")]
        /// <summary>
        /// Indicates Bankruptcy Lawyer.
        /// </summary>
        Part_Filled = 2,

        [Display(Name = "Filled but not collected")]
        /// <summary>
        /// Indicates Employment Lawyer.
        /// </summary>
        Filled_but_not_collected = 3,
        
    }
}
