using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilet.Entity.Entity
{
    [Table("Destinasyonlar")]
    public class Destinasyon:EntityBase
    {
        [Required]
        public string VarisYer { get; set; }
        //Relations
        public virtual List<Sefer> Seferler { get; set; }
    }
}
