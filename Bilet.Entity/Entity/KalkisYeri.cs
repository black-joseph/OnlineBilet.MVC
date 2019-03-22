using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilet.Entity.Entity
{
    [Table("KalkisYerleri")]
    public class KalkisYeri:EntityBase
    {
        [Required]
        public string KalkisYer { get; set; }
        //Relations
        public virtual List<Guzergah> Guzergahlar { get; set; }

    }
}
