using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProjectClient
{
    public class Details
    {
        public Guid Id { get; set; }

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


        public override string ToString()
        {
            return $"{VinNo}\t {ManufacturerName} \t {YearOfModel} \t {ModelName} \t {NoOfAccidents} \t {NoOfServices}" +
               $"\t {OwnerName} \t {ActualPrice} \t {SellingPrice} \t {Milage} \n";
        }
    }
}
