using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedSchedlr.Data.Entities;
using MedSchedlr.Service;
using MedSchedlr.Service.Interfaces;

namespace MedSchedlr.Web.Controllers
{
    public class AccountController : Controller
    {
        IAccountService _accountService;

        public AccountController()
        {
            _accountService = new AccountService();
        }

        [HttpGet]
        public Account[] Teste()
        {
            var teste = _accountService.GetAll();
            return teste.ToArray();
        }

        [HttpGet]
        public bool Login(string email, string password)
        {
            return true;
        }

        [HttpGet]
        public void Insert(Account account)
        {
            _accountService.Insert(account);
        }

        [HttpGet]
        public void Update(Account account)
        {
            _accountService.Update(account);
        }

        [HttpGet]
        public void Delete(Account account)
        {
            _accountService.Delete(account);
        }

        [HttpGet]
        public Account[] GetAll()
        {
            var account = _accountService.GetAll();

            return account.ToArray();
        }

        [HttpGet]
        public Account GetById(int id)
        {
            var account = _accountService.GetById(id);

            return account;
        }
    }
}