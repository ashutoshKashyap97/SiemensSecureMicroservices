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
            var workList = new List<Work>();
            workList.Add(
                new Work
                {
                    Id =1,
                    ProcessName = "Molding",
                    ProcessDescription = "Heat and mold",
                    CreatedDate = DateTime.Now,
                    Owner = "Musthafa"
                });
            return await Task.FromResult(workList);
        }
        public Task<Work> UpdateWork(Work work)
        {
            throw new NotImplementedException();
        }
    }
}
