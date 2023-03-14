using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiBDCLINICA.Models
{
    public partial class Distrito
    {
        public Distrito()
        {
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public string Coddis { get; set; }
        public string Nomdis { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
