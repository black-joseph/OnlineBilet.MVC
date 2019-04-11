using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilet.Entity.Entity
{
    [Table("BiletSatisDetaylar")]
    public class BiletSatisDetay : EntityBase
    {
        public int KoltukNo { get; set; }
        public decimal Fiyat { get; set; }
        public string Cinsiyet { get; set; }
        public int? BiletSatisId { get; set; }
        public int? SeferSaatId { get; set; }
        //relations
        [ForeignKey("BiletSatisId")]
        public virtual BiletSatis BiletSatis { get; set; }
        [ForeignKey("SeferSaatId")]
        public virtual SeferSaat SeferSaat { get; set; }
    }
}
