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
    public class AccountService : Service<Account>, IAccountService
    {
        private IAccountRepository _repository;

        public AccountService()
        {
            _repository = new AccountRepository(_context);
        }
    }
}
