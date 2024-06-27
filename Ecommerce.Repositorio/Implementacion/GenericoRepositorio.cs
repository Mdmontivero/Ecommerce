using Ecommerce.Repositorio.DBcontext;
using Ecommerce.Repositorio.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositorio.Implementacion
{
    public class GenericoRepositorio<TModel>:IGenericRepositorio<TModel>where TModel : class
    {
        private readonly DbecommerceContext _dbContext;

        public GenericoRepositorio(DbecommerceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TModel> Get(Expression<Func<TModel, bool>>? filtro = null)
        {
            IQueryable<TModel> consulta = (filtro == null) ? _dbContext.Set<TModel>(): _dbContext.Set<TModel>().Where(filtro);
            return consulta;
   
        }

        public async Task<TModel> Create(TModel model)
        {
            try
            {
                 _dbContext.Set<TModel>().Add(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<bool> Update(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Update(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Delete(TModel model)
        {

            try
            {
                _dbContext.Set<TModel>().Remove(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
