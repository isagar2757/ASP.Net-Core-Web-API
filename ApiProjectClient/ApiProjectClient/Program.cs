using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiProjectClient
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }


        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://apiproject-env.vaagfmpiwv.us-east-2.elasticbeanstalk.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                string json;
                Details detail;
                HttpContent content;
                HttpResponseMessage response;

                #region get all details
                //get all details
                response = await client.GetAsync("/api/Details/alldetails");

                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();

                    // Console.WriteLine(json);

                    IEnumerable<Details> details =
                        JsonConvert.DeserializeObject<IEnumerable<Details>>(json);
                    Console.WriteLine("All Details");
                    foreach (Details c in details)
                    {
                        Console.WriteLine(c);
                    }
                }
                else
                    Console.WriteLine("Internal Server error");
                #endregion

                #region add a new detail
                Console.WriteLine("All Details/n/n");
                detail = new Details
                {
                    VinNo = 100200305,
                    ManufacturerName = "Buggati",
                    YearOfModel = 2016,
                    ModelName = "Veron",
                    NoOfAccidents = 1,
                    NoOfServices = 1,
                    OwnerName = "Manthan",
                    ActualPrice = 6000000,
                    SellingPrice = 5000000,
                    Milage = 2500
                };

                json = JsonConvert.SerializeObject(detail);
                //content = new StringContent(json, Encoding.UTF8, "application/json");
                //response = await client.PostAsync("/api/Details", content);

                response = await client.PostAsJsonAsync("/api/Details", detail);

                Console.WriteLine($"status from POST {response.StatusCode}");
                response.EnsureSuccessStatusCode();
                Console.WriteLine($"added resource at {response.Headers.Location}");
                json = await response.Content.ReadAsStringAsync();

                Console.WriteLine("The detail has been inserted " + json);

                #endregion

                #region get details after Addition

                Console.WriteLine("Get Details after Addition/n/n");
                response = await client.GetAsync("/api/Details/alldetails");

                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();

                    // Console.WriteLine(json);

                    IEnumerable<Details> details =
                        JsonConvert.DeserializeObject<IEnumerable<Details>>(json);
                    foreach (Details c in details)
                    {
                        Console.WriteLine(c);
                    }
                }
                else
                    Console.WriteLine("Internal Server error");

                #endregion

                #region update the existing detail
                Console.WriteLine("Update Details");
                Console.WriteLine();
                detail = new Details
                {

                    Id = new Guid("cc9e3f1b-21d1-4f0a-8300-d5840d097f81"),
                    VinNo = 100200305,
                    ManufacturerName = "Buggati",
                    YearOfModel = 2016,
                    ModelName = "Veron",
                    NoOfAccidents = 3,
                    NoOfServices = 1,
                    OwnerName = "Manthan",
                    ActualPrice = 6000000,
                    SellingPrice = 4000000,
                    Milage = 5000

                };
                json = JsonConvert.SerializeObject(detail);
                content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PutAsync("/api/Details/cc9e3f1b-21d1-4f0a-8300-d5840d097f81", content);

                response =
                await client.PutAsJsonAsync("/api/Details/cc9e3f1b-21d1-4f0a-8300-d5840d097f81", detail);
                Console.WriteLine($"status from PUT {response.StatusCode}");
                response.EnsureSuccessStatusCode();

                #endregion

                #region get details after Updation
                Console.WriteLine("Get Details after Updation/n/n");
                response = await client.GetAsync("/api/Details/alldetails");

                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();

                    // Console.WriteLine(json);

                    IEnumerable<Details> details =
                        JsonConvert.DeserializeObject<IEnumerable<Details>>(json);
                    foreach (Details c in details)
                    {
                        Console.WriteLine(c);
                    }
                }
                else
                    Console.WriteLine("Internal Server error");
                #endregion

                #region delete the specified detail

                response = await client.DeleteAsync("/api/Details/633ed966-4350-4ab7-a428-72b9d15d3bdb");
                Console.WriteLine($"status from DELETE {response.StatusCode}");
                response.EnsureSuccessStatusCode();

                #endregion

                #region get details after Deletion
                Console.WriteLine("Get Details after Deletion/n/n");
                response = await client.GetAsync("/api/Details/alldetails");

                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();

                    // Console.WriteLine(json);

                    IEnumerable<Details> details =
                        JsonConvert.DeserializeObject<IEnumerable<Details>>(json);
                    foreach (Details c in details)
                    {
                        Console.WriteLine(c);
                    }
                }
                else
                    Console.WriteLine("Internal Server error");
                #endregion
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

    }
}
