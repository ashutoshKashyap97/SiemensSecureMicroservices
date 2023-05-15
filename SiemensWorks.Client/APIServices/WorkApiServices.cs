using IdentityModel.Client;
using Newtonsoft.Json;
using SiemensWorks.Client.Models;

namespace SiemensWorks.Client.APIServices
{
    public class WorkApiServices : IWorkApiServices
    {
        public Task<Work> CreateWork(Work work)
        {
            throw new NotImplementedException();
        }

        public Task DeleteWork(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Work> GetWork(string id)
        {
            throw new NotImplementedException();
        }

        





        public async Task<IEnumerable<Work>> GetWorks()
        {
            //var apiClientCredentials = new ClientCredentialsTokenRequest
            //{
            //    Address = "https://localhost:5200/connect/token",
            //    ClientId = "siemensWorksClient",
            //    ClientSecret = "secret",
            //    Scope = "siemensWorksAPI"
            //};

            //var client = new HttpClient();
            //var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5200");
            //if (disco.IsError)
            //{
            //    return null;
            //}
            //var tokenResponse = await client.RequestClientCredentialsTokenAsync(apiClientCredentials);
            //if (tokenResponse.IsError)
            //{
            //    return null;
            //}



            //var apiClient = new HttpClient();


            //apiClient.SetBearerToken(tokenResponse.AccessToken);

            //var response = await client.GetAsync("https://localhost:7092/api/works");
            //response.EnsureSuccessStatusCode();

            //var content = await response.Content.ReadAsStringAsync();

            //List<Work> workList = JsonConvert.DeserializeObject<List<Work>>(content);
            //return workList;

            var workList = new List<Work>();
            workList.Add(
                new Work
                {
                    Id = 1,
                    ProcessName = "Molding",
                    ProcessDescription = "Heat and mold",
                    CreatedDate = DateTime.Now,
                    Owner = "Musthafa"
                });
            workList.Add(
               new Work
               {
                   Id = 2,
                   ProcessName = "Grinding",
                   ProcessDescription = "Use the grinder to smooth the surface",
                   CreatedDate = DateTime.Now,
                   Owner = "Rohan"
               });
            workList.Add(
               new Work
               {
                   Id = 3,
                   ProcessName = "Turning",
                   ProcessDescription = "Use the Lathe machine to shape the metal block",
                   CreatedDate = DateTime.Now,
                   Owner = "Vansh"
               });
            workList.Add(
               new Work
               {
                   Id = 4,
                   ProcessName = "Meatal Casting",
                   ProcessDescription = "Pour the melted metal into the sand cast",
                   CreatedDate = DateTime.Now,
                   Owner = "Pushpa"
               });
            return await Task.FromResult(workList);
        }
        public Task<Work> UpdateWork(Work work)
        {
            throw new NotImplementedException();
        }
    }
}
