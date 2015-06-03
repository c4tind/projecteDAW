using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArmyHammerProject.Models
{
    public class Raça
    {
        [Key]
        public int ID { set; get; }
        [Required, MinLength(3)]
        public string Nom { set; get; }
        [Required, MinLength(3)]
        public string Informacio { set; get; }
        public virtual ICollection<Miniatura> Miniatures { get; set; }
        public virtual ICollection<Llista> Llistes { get; set; }
    }
}