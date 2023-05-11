using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiemensWorkAPI.Model;

namespace SiemensWorkAPI.Data
{
    public class SiemensWorkAPIContext : DbContext
    {
        public SiemensWorkAPIContext (DbContextOptions<SiemensWorkAPIContext> options)
            : base(options)
        {
        }

        public DbSet<SiemensWorkAPI.Model.Work> Work { get; set; } = default!;
    }
}
