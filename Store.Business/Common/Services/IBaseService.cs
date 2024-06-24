using System.Linq.Expressions;
using Store.Entities.Common.Models;

namespace Store.Business.Common.Services;

public interface IBaseService<TEntity, TDto> {
     Task<TDto> GetFirst(Expression<Func<TEntity, bool>> predicate, string[]? includes = null, bool applyAsNoTracking = true);
     Task<List<TDto>> GetList(Expression<Func<TEntity, bool>> predicate, string[]? includes = null, bool applyAsNoTracking = true);
     Task<TDto> GetById(int id, string[]? includes = null, bool applyAsNoTracking = true);
     Task<TDto> Create(TDto entity);
     Task<TDto> Update(TDto entity);
     Task Delete(int id);
}