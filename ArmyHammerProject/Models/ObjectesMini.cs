using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArmyHammerProject.Models
{
    public class ObjectesMini
    {
        [Key]
        public int ID { set; get; }
        public virtual Miniatura Miniatura { set; get; }
        [Required]
        public int MiniaturaID { set; get; }
        public virtual Objecte Objecte { set; get; }
        [Required]
        public int ObjecteID { set; get; }
    }
}