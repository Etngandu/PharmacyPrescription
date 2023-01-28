using ENB.PharmaciesAndPrescriptions.Entities;

namespace ENB.PharmaciesAndPrescriptions.MVC.Models
{
    public class DisplayPrescriptionItem
    {
        public int Id { get; set; }
        public Prescription? Prescription { get; set; }

        public int PrescriptionId { get; set; }

        public Drug_medication? Drug_medication { get; set; }
        
        public int Drug_medicationId { get; set; }

        public Customer? Customer { get; set; }

        public int CustomerId { get; set; }


        public int Prescription_quantity { get; set; }
        
        public string Instructions_to_customer { get; set; } = String.Empty;

        public string NameCustomer { get; set; }= String.Empty; 

        public string NamePhysician { get; set; }=String.Empty;

        public string NumberPrescription { get; set; } = String.Empty;

        public string DrugName { get; set; } = string.Empty;

        public DateTime DateCreated { get; set; }
       
        public DateTime DateModified { get; set; }
    }
}
