using ENB.PharmaciesAndPrescriptions.Entities;
using ENB.PharmaciesAndPrescriptions.Entities.Collections;
using ENB.PharmaciesAndPrescriptions.MVC.Models;
using System.ComponentModel.DataAnnotations;


namespace ENB.PharmaciesAndPrescriptions.MVC.Models
{
    public class DisplayDrugCompany
    {
        #region "Public Properties"


        public int Id { get; set; }
        
        public string Company_name { get; set; } = string.Empty;
       

        public string MgfLicence { get; set; } = string.Empty;

        
        public string EmailAddress { get; set; } = string.Empty;

       
        public string PhoneNumber { get; set; } = string.Empty;

        
        public string ContactPerson { get; set; } = string.Empty;

        public string Other_details { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        
        public DateTime DateModified { get; set; }

        #endregion
    }
}
