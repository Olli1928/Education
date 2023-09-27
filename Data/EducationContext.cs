using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Education.Models;

namespace Education.Data
{
    public class EducationContext : DbContext
    {
        public EducationContext (DbContextOptions<EducationContext> options)
            : base(options)
        {
        }

        public DbSet<Education.Models.Thr3ad> Thr3ad { get; set; } = default!;
    }
}
