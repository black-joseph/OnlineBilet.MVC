using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilet.Entity.Entity
{
    [Table("Guzergahlar")]
    public class Guzergah : EntityBase
    {
        public int KalkisYeriId { get; set; }
        public int DestinasyonId { get; set; }
        //relations
        public virtual List<Sefer> Seferler { get; set; }
        [ForeignKey("KalkisYeriId")]
        public virtual KalkisYeri KalkisYeri { get; set; }
        [ForeignKey("DestinasyonId")]
        public virtual Destinasyon Destinasyon { get; set; }

    }
}
