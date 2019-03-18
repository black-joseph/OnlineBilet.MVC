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
        public string KalkisYeri { get; set; }
        [Required]
        public string Destinasyon { get; set; }
        public DateTime GidisTarihi { get; set; }
        //relations
        public virtual List<SeferProgram> SeferProgramlar { get; set; }

    }
}
