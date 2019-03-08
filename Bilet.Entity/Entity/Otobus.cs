using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilet.Entity.Entity
{
    [Table("Otobusler")]
    public class Otobus : EntityBase
    {
        [StringLength(7)]
        public string Plaka { get; set; }
        public int SeferProgramId { get; set; }
        //relations
        [ForeignKey("SeferProgramId")]
        public virtual SeferProgram SeferProgram { get; set; }
    }
}
