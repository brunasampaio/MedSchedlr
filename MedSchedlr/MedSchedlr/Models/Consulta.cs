//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MedSchedlr.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Consulta
    {
        public int idConsulta { get; set; }
        public int idMedico { get; set; }
        public int idPaciente { get; set; }
    
        public virtual Medico Medico { get; set; }
        public virtual Paciente Paciente { get; set; }
    }
}
