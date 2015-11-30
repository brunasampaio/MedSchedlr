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
    public class ConsultaMedicaService : Service<ConsultaMedica>, IConsultaMedicaService
    {
        private IConsultaMedicaRepository _repository;
        public ConsultaMedicaService()
        {
            _repository = new ConsultaMedicaRepository(_context);
        }
    }
}
