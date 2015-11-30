using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedSchedlr.Data.Entities;
using MedSchedlr.Data.Repositories.Base;

namespace MedSchedlr.Data.Repositories.Interfaces
{
    public interface IAccountRepository : IRepository<Account>, IDisposable
    {
        bool Login(string email, string password);
    }
}
