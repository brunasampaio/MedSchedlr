using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MedSchedlr.Data.Entities.Enumerators;

namespace MedSchedlr.Data.Entities
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public TipoPlano Plano { get; set; }
    }
}
