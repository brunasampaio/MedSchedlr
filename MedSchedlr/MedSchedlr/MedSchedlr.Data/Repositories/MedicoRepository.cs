using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedSchedlr.Data.Context;
using MedSchedlr.Data.Entities;
using MedSchedlr.Data.Repositories.Base;
using MedSchedlr.Data.Repositories.Interfaces;

namespace MedSchedlr.Data.Repositories
{
    public class MedicoRepository : Repository<Medico>, IMedicoRepository
    {
        public MedicoRepository(MedSchedlrContext context) : base(context) { }

    }
}
