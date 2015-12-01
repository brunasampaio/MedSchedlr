using System;

namespace MedSchedlr.Data.Entities
{
    public class ConsultaMedica
    {
        public int Id { get; set; }
        public Consultorio Consultorio { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime DataHora { get; set; }
    }
}
