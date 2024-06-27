﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositorio.Service
{
    public interface IGenericRepositorio<TModel> where TModel : class
    {
        IQueryable<TModel> Get(Expression<Func<TModel,bool>>?filtro = null);
 
        Task<TModel> Create(TModel model);
        Task<bool> Update(TModel model);
        Task<bool> Delete(TModel model);
        
    }
}
