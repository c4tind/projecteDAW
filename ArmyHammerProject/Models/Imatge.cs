using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ArmyHammerProject.Models
{
    public class Imatge
    {
        public int ImatgeId { get; set; }
        [StringLength(255)]
        public string NomImatge { get; set; }
        public FileType FileType { get; set; }
        public int UsuariID { get; set; }
        public virtual Miniatura Miniatura { get; set; }
    }
}