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
        [Range(1, 50, ErrorMessage = "Koltuk no 1-50 arası olmalıdır!")]
        public int KoltukNo { get; set; }
        public string KoltukTürü { get; set; }
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
