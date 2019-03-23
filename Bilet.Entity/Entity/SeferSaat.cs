using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilet.Entity.Entity
{
    [Table("SeferSaatler")]
    public class SeferSaat:EntityBase
    {
        [Required]
        public string KalkisSaati { get; set; }     
        public int SeferId { get; set; }
        //Relations
        
        [ForeignKey("SeferId")]
        public virtual Sefer Sefer { get; set; }
        public virtual List<Otobus> Otobusler { get; set; }
    }
}
