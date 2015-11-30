using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedSchedlr.Data.Entities;
using MedSchedlr.Data.Repositories;
using MedSchedlr.Data.Repositories.Interfaces;
using MedSchedlr.Service.Base;
using MedSchedlr.Service.Interfaces;

namespace MedSchedlr.Service
{
    public class MedicoService : Service<Medico>, IMedicoService
    {
        private IMedicoRepository _repository;
        public MedicoService()
        {
            _repository = new MedicoRepository(_context);
        }
    }
}
