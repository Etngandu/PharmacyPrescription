using ENB.PharmaciesAndPrescriptions.Entities;
using ENB.PharmaciesAndPrescriptions.Entities.Collections;
using ENB.PharmaciesAndPrescriptions.MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace ENB.PharmaciesAndPrescriptions.MVC.Models
{
    public class DisplayPhysician
    {
        #region "Public Properties"

        public int Id { get; set; }
        public string FirstName { get; set; }=string.Empty;

       
        public string LastName { get; set; }=string.Empty;

        public string EmailAddress { get; set; } = String.Empty;

        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; } = String.Empty;


        [Display(Name = "Date of birth")]
        [DisplayFormat(DataFormatString = "{0: MM/dd/yyyy}")]
        public DateTime DateOfBirth
        {
            get;
            set;
        }
       
        
        public string FullName { get; set; }=string.Empty;

        public Prescriptions? Prescriptions { get; set; }

        public string Other_details { get; set; } = string.Empty;
        #endregion

    }
}
