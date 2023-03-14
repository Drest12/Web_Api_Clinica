using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiBDCLINICA.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            Cita = new HashSet<Cita>();
        }

        public string Codpac { get; set; }
        public string Nompac { get; set; }
        public string Dnipac { get; set; }
        public string TelCel { get; set; }
        public string Dirpac { get; set; }
        public string Coddis { get; set; }
        public int? Estado { get; set; }

        public virtual Distrito CoddisNavigation { get; set; }
        public virtual ICollection<Cita> Cita { get; set; }
    }
}
