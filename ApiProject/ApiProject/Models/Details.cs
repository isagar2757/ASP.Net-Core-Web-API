using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Models
{
    public partial class Details
    {
        public Guid Id { get; set; }
        [Required]   


        public int VinNo { get; set; }
        public string ManufacturerName { get; set; }
        public int YearOfModel { get; set; }
        public string ModelName { get; set; }
       
        public int NoOfAccidents { get; set; }
        public int NoOfServices { get; set; }
        public string OwnerName { get; set; }
        
        public int ActualPrice { get; set; }
        public int SellingPrice { get; set; }
        public int Milage { get; set; }
    }
}
