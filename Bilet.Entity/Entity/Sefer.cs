using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilet.Entity.Entity
{
    [Table("Seferler")]
    public class Sefer : EntityBase
    {
        [Required]
        public string KalkisTarihi { get; set; }
        public int GuzergahId { get; set; }
        
        //relations
        
        [ForeignKey("GuzergahId")]
        public virtual Guzergah Guzergah { get; set; }
        public virtual List<SeferSaat> SeferSaatler { get; set; }

    }
}
