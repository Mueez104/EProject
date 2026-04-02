using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineCaters.Models;

namespace OnlineCaters.Data
{
    public class CatersContext : DbContext
    {
        public CatersContext (DbContextOptions<CatersContext> options)
            : base(options)
        {
        }

        public DbSet<OnlineCaters.Models.Userlogin> Userlogin { get; set; } = default!;
    }
}
