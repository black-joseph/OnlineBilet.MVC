using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilet.Entity.Entity
{
    [Table("SeferProgramlar")]
    public class SeferProgram : EntityBase
    {
        [Required]        
        public DateTime KalkisTarihi { get; set; }       
        public DateTime VarisTarihi { get; set; }
        public int SeferId { get; set; }
        public int BiletSatisId { get; set; }
        //relations
        [ForeignKey("BiletSatisId")]
        public virtual BiletSatis BiletSatis { get; set; }
        [ForeignKey("SeferId")]
        public virtual Sefer Sefer { get; set; }
        public virtual List<Otobus> Otobusler { get; set; }

    }
}
