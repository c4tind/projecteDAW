using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArmyHammerProject.Models
{
    public class Miniatura
    {
        [Key]
        public int ID { set; get; }
        [Required, MinLength(3)]
        public string Nom { set; get; }
        [Required, MinLength(3)]
        public string Informacio { set; get; }
        [Required]
        public int Punts { set; get; }
        [Required, Range(1, 20)]
        public int MidaMinima { set; get; }
        [Required, Range(1, 10)]
        public string TipusTropa { set; get; }
        [Required, Range(1, 10)]
        public int Moviment { set; get; }
        [Required, Range(1, 10)]
        public int HabilitatArmes { set; get; }
        [Required, Range(1, 10)]
        public int HabilitatProjectils { set; get; }
        [Required, Range(1, 10)]
        public int Força { set; get; }
        [Required, Range(1, 10)]
        public int Resistencia { set; get; }
        [Required, Range(1, 10)]
        public int Ferides { set; get; }
        [Required, Range(1, 10)]
        public int Iniciativa { set; get; }
        [Required, Range(1, 10)]
        public int Atac { set; get; }
        [Required, Range(1, 10)]
        public int Lideratge { set; get; }
        [Range(1, 6)]
        public int? SalvacioArmadura { set; get; }
        [Range(1, 6)]
        public int? SalvacioEspecial { set; get; }
        [Range(1, 6)]
        public int? Regen { set; get; }
        public virtual Raça Raça { set; get; }
        [Required]
        public int RaçaID { set; get; }
        public virtual ICollection<ObjectesMini> Objectes { get; set; }
        public virtual ICollection<MinisPerLlista> Llistes { get; set; }
        public virtual ICollection<Raça> Races { get; set; }
    }
}