using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Matis_Diana_ProiectExamen.Models;

namespace Matis_Diana_ProiectExamen.Data
{
    public class Matis_Diana_ProiectExamenContext : DbContext
    {
        public Matis_Diana_ProiectExamenContext (DbContextOptions<Matis_Diana_ProiectExamenContext> options)
            : base(options)
        {
        }

        public DbSet<Matis_Diana_ProiectExamen.Models.Phone> Phone { get; set; }

        public DbSet<Matis_Diana_ProiectExamen.Models.Brand> Brand { get; set; }

        public DbSet<Matis_Diana_ProiectExamen.Models.Condition> Condition { get; set; }
    }
}
