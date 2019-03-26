using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilet.Entity.Entity
{
    [Table("Koltuklar")]
    public class Koltuk : EntityBase
    {
        public int KoltukNo { get; set; }
        public string KoltukDurumu { get; set; }
        public decimal Fiyat { get; set; }
        public string Cinsiyet { get; set; }
        public int? BiletSatisId { get; set; }
        public int? OtobusId { get; set; }
        //relations
        [ForeignKey("BiletSatisId")]
        public virtual BiletSatis BiletSatis { get; set; }
        [ForeignKey("OtobusId")]
        public virtual Otobus Otobus { get; set; }
    }
}
