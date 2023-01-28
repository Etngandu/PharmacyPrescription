using ENB.PharmaciesAndPrescriptions.Entities;
using ENB.PharmaciesAndPrescriptions.Entities.Collections;
using ENB.PharmaciesAndPrescriptions.MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace ENB.PharmaciesAndPrescriptions.MVC.Models
{
    public class DisplayCustomer
    {
        #region "Public Properties"

        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;


        public string LastName { get; set; } = string.Empty;

        public string FullName { get; set; }=string.Empty;

        
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth
        {
            get;
            set;
        }

        public string EmailAddress { get; set; } = String.Empty;

        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; } = String.Empty;
        public string Credit_card_Number { get; set; } = string.Empty;
        
        public string Card_expiry_date { get; set; } = string.Empty;         
       
        public string Other_details { get; set; } = string.Empty; 
        
        public Prescriptions? Prescriptions { get; set; }
        
        public DateTime DateCreated { get ; set ; }

        public DateTime DateModified { get ; set ; }
        #endregion
    }
}
