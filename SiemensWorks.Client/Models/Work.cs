namespace SiemensWorks.Client.Models
{
    public class Work
    {
        public int Id { get; set; }
        public string ProcessName { get; set; }
        public string ProcessDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Owner { get; set; }
    }
}
