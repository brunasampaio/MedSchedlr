﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedSchedlr.Service.Base
{
    public interface IService<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll();
        void Insert(TEntity obj);
        void Delete(TEntity obj);
        void Update(TEntity obj);
    }
}
