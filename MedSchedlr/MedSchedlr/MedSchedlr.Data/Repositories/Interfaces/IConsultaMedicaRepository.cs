using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedSchedlr.Data.Entities;
using MedSchedlr.Data.Repositories.Base;

namespace MedSchedlr.Data.Repositories.Interfaces
{
    public interface IConsultaMedicaRepository : IRepository<ConsultaMedica>, IDisposable
    {
    }
}
