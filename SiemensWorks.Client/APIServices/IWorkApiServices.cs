using SiemensWorks.Client.Models;

namespace SiemensWorks.Client.APIServices
{
    public interface IWorkApiServices
    {
        Task<IEnumerable<Work>> GetWorks();
        Task<Work> GetWork(string id);
        Task<Work> CreateWork (Work work);
        Task<Work> UpdateWork (Work work);
        Task DeleteWork (string id);
    }
}
