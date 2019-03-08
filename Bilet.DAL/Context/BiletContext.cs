using Bilet.Entity.Entity;
using Bilet.Entity.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilet.DAL.Context
{
    public class BiletContext: IdentityDbContext<ApplicationUser>
    {
        public BiletContext() : base("BiletContext")
        {

        }
        public virtual DbSet<BiletSatis> BiletSatislar { get; set; }
        public virtual DbSet<BiletSatisDetay> BiletSatisDetaylar { get; set; }
        public virtual DbSet<Otobus> Otobusler { get; set; }
        public virtual DbSet<Sefer> Seferler { get; set; }
        public virtual DbSet<SeferProgram> SeferProgramlar { get; set; }
    }
}
