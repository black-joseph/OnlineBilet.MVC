using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilet.Entity.Identity
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string Ad { get; set; }
        [Required]
        [StringLength(50)]
        public string Soyad { get; set; }
    }
}
