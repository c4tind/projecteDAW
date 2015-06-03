using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArmyHammerProject.Models
{
    public class Objecte
    {
        [Key]
        public int ID { set; get; }
        [Required, MinLength(3)]
        public string Nom { set; get; }
        [Range(0, 10)]
        public int? Moviment { set; get; }
        [Range(0, 10)]
        public int? HabilitatArmes { set; get; }
        [Range(0, 10)]
        public int? HabilitatProjectils { set; get; }
        [Range(0, 10)]
        public int? Força { set; get; }
        [Range(0, 10)]
        public int? Resistencia { set; get; }
        [Range(0, 10)]
        public int? Ferides { set; get; }
        [Range(0, 10)]
        public int? Iniciativa { set; get; }
        [Range(0, 10)]
        public int? Atac { set; get; }
        [Range(0, 10)]
        public int? Lideratge { set; get; }
        [Range(0, 6)]
        public int? SalvacioArmadura { set; get; }
        [Range(0, 6)]
        public int? SalvacioEspecial { set; get; }
        [Range(0, 6)]
        public int? Regen { set; get; }
        public int BonusTotal { set; get; }
        public virtual ICollection<ObjectesMini> Miniatures { get; set; }
    }
}