using ArmyHammerProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArmyHammerProject.Models
{
    public class Llista
    {
        [Key]
        public int ID { set; get; }
        [Required, MinLength(3)]
        public string Nom { set; get; }
        [Required]
        public int Punts { set; get; }
        [Required]
        public virtual string UsuariID { set; get; }
        public virtual ApplicationUser Usuari { set; get; }
        public virtual Raça Raça { set; get; }
        [Required]
        public int RaçaID { set; get; }
        public virtual ICollection<MinisPerLlista> Miniatures { get; set; }
    }
}