using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Geo.Models;

namespace Geo.Data
{
    public class GeoContext : DbContext
    {
        public GeoContext (DbContextOptions<GeoContext> options)
            : base(options)
        {
        }

        public DbSet<Geo.Models.Todolist> Todolist { get; set; } = default!;

        public DbSet<Geo.Models.Countriestovisit> Countriestovisit { get; set; }

        public DbSet<Geo.Models.Obiective> Obiective { get; set; }

        public DbSet<Geo.Models.Carte> Carte { get; set; }

        public DbSet<Geo.Models.Materie> Materie { get; set; }

        public DbSet<Geo.Models.Whocansee> Whocansee { get; set; }

        public DbSet<Geo.Models.Incredere> Incredere { get; set; }
    }
}
