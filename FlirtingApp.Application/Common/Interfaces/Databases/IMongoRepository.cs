﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FlirtingApp.Domain.Common;

namespace FlirtingApp.Application.Common.Interfaces.Databases
{
	public interface IMongoRepository<TEntity> where TEntity: AuditableEntity
	{
		Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
		Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
		//Task<PagedResult<TEntity>> BrowseAsync<TQuery>(Expression<Func<TEntity, bool>> predicate,
		//	TQuery query) where TQuery : PagedQueryBase;
		Task AddAsync(TEntity entity);
		Task UpdateAsync(TEntity entity);
		Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);
		Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
