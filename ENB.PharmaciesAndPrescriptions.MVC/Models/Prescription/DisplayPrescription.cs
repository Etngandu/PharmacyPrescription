using ENB.PharmaciesAndPrescriptions.Entities;
using ENB.PharmaciesAndPrescriptions.Entities.Collections;
using ENB.PharmaciesAndPrescriptions.MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace ENB.PharmaciesAndPrescriptions.MVC.Models
{
    public class DisplayPrescription
    {
        #region "Public Properties"

        public int Id { get; set; }
        public Customer? Customer { get; set; }

        public int CustomerId { get; set; }

        
        public Physician? Physician { get; set; }

        public int PhysicianId { get; set; }

       
        public Ref_Prescription_status Prescription_Status { get; set; }

        
        public Ref_payment_method Payment_Method { get; set; }

        
        [Display(Name = "Presciption issue date")]
        public DateTime Presciption_issue_date { get; set; }

        
        [Display(Name = "Presciption filled date")]
        public DateTime Presciption_filled_date { get; set; } 

        public DateTime DateCreated { get ; set ; }

        
        public DateTime DateModified { get ; set ; }

        public string PhysicianName { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;

        public string PrescriptionNumber { get; set; } = string.Empty;
        
        #endregion
    }
}
