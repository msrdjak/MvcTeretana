using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTeretana.Models
{
    public class Clan
    {
        public int Id { get; set; }
        
        public string Ime { get; set; }

        
        public string Prezime { get; set; }

        [Display(Name = "Godina rođenja")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyy}", ApplyFormatInEditMode = true)]
        public DateTime GodinaRodenja { get; set; }

        
        public string Spol { get; set; }

        [Range(1,7)]
        [Display(Name = "Razina članarine")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal RazinaClanarine { get; set; }

        

        [Display(Name = "članarina vrijedi do")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyy}", ApplyFormatInEditMode = true)]
        public DateTime ClanarinaVrijediDo { get; set; }

        [Display(Name = "Vrsta treninga")]
        public string VrstaTreninga { get; set; }
    }
}
