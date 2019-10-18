using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoiosZadatak.Models
{
    public class KoiosDbContext : DbContext 
    {
        public KoiosDbContext(DbContextOptions<KoiosDbContext> options)
            : base(options)
        {
        }
        public KoiosDbContext()
        {

        }
        public DbSet<Drzava> Drzave { get; set; }
        public DbSet<Naselje> Naselja { get; set; }
    }
}
