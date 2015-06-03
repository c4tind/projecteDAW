using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArmyHammerProject.Models
{
    public class MinisPerLlista
    {
        [Key]
        public int ID { set; get; }
        [Required]
        public int Quantitat { set; get; }
        public virtual Miniatura Miniatura { set; get; }
        [Required]
        public int MiniaturaID { set; get; }
        public virtual Llista Llista { set; get; }
        [Required]
        public int LlistaID { set; get; }
    }
}