using Bilet.Entity.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilet.Entity.Entity
{
    [Table("BiletSatislar")]
    public class BiletSatis : EntityBase
    {
        public DateTime IslemTarihi { get; set; }
        public string UserId { get; set; }
        //relations
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public virtual List<Koltuk> Koltuklar { get; set; }
    }
}
