using SiemensWorkAPI.Model;

namespace SiemensWorkAPI.Data
{
    public class SiemensWorkContextSeed
    {
        public static void SeedAsync(SiemensWorkAPIContext worksContext)
        {
            if (!worksContext.Work.Any())
            {
                var works = new List<Work>
                {
                    new Work
                    {
                        Id = 1,
                        ProcessName = "Cutting",
                        ProcessDescription = "Cut the sheet metal into a square shape",
                        CreatedDate = DateTime.Now,
                        Owner = "Ashu"

                    },
                    new Work
                    {
                        Id = 2,
                        ProcessName = "Grinding",
                        ProcessDescription = "Use the grinder to smooth the surface",
                        CreatedDate = DateTime.Now,
                        Owner = "Rohan"

                    },
                    new Work
                    {
                        Id = 3,
                        ProcessName = "Turning",
                        ProcessDescription = "Use the Lathe machine to shape the metal block",
                        CreatedDate = DateTime.Now,
                        Owner = "Vansh"

                    },
                    new Work
                    {
                        Id = 4,
                        ProcessName = "Meatal Casting",
                        ProcessDescription = "Pour the melted metal into the sand cast",
                        CreatedDate = DateTime.Now,
                        Owner = "Pushpa"

                    },
                    new Work
                    {
                        Id = 5,
                        ProcessName = "Assembly",
                        ProcessDescription = "Assenble all the finished parts",
                        CreatedDate = DateTime.Now,
                        Owner = "Monika"

                    },
                };
                worksContext.Work.AddRange(works);
                worksContext.SaveChanges();
            }
        }
    }
}
