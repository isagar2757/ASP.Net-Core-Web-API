using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProject.Models;

namespace ApiProject.Services
{
   
    public class SampleDetails
    {
        private readonly ISampleServices _detailsService;
        public SampleDetails(ISampleServices detailsService)
        {
            _detailsService = detailsService;
        }

        private int[] vinNo = { 100200300, 100200301, 100200302, 100200303, 100200304 };
        private string[] manufacturerName = new[]
        {
            "Honda",
            "Toyota",
            "Lamborghini ",
            "BMW",
            "Audi"
        };
        private int[] yearOfModel = { 2015, 2016, 2017, 2018, 2019 };

        private string[] modelName = new[]
       {
            "Civic",
            "Camery",
            "Urus",
            "Series-3",
            "A8"
        };
        private int[] accidentNo = { 0, 2, 3, 1, 0 };
        private int[] servicesNo = { 5, 4, 3, 2, 0 };
        private string[] ownerName = new[]
       {
            "Sagar",
            "Rahul",
            "Vivek",
            "Kaveri",
            "Yash"
        };
        private int[] actualPrice = { 30000, 40000, 4500000, 50000, 60000 };
        private int[] sellingPrice = { 25000, 35000, 4000000, 45000, 50000 };
        private int[] milage = { 25000, 20000, 15000, 10000, 3000 };


        public async Task CreateSamplevinNosAsync()
        {
            var vinNos = new List<Details>();
            for (int i = 0; i < 5; i++)
            {
                vinNos.Add(new Details
                {
                   
                    VinNo = vinNo[i],
                    ManufacturerName = manufacturerName[i],
                    YearOfModel = yearOfModel[i],
                    ModelName = modelName[i],
                    OwnerName = ownerName[i],
                    NoOfAccidents = accidentNo[i],
                    NoOfServices = servicesNo[i],
                    ActualPrice = actualPrice[i],
                    SellingPrice = sellingPrice[i],
                    Milage = milage[i]
                });
            }
            await _detailsService.AddRangeAsync(vinNos);
        }
    }
}
