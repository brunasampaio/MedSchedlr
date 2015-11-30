using System;
using MedSchedlr.Data.Context;
using MedSchedlr.Data.Entities;
using MedSchedlr.Data.Repositories.Base;
using MedSchedlr.Data.Repositories.Interfaces;

namespace MedSchedlr.Data.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(MedSchedlrContext context) : base(context) { }

        public void Teste()
        {

        }

        public bool Login(string email, string password)
        {
            return true;
        }
        
    }
}
