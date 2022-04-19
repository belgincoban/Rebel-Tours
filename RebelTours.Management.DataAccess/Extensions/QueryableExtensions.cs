using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RebelTours.Management.DataAccess.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TEntity> IncludeMultiple<TEntity>(
            this IQueryable<TEntity> queryable,
            IEnumerable<string> includings)
            where TEntity:class
        {
            if (includings != null)
            {
                foreach (var navProperty in includings)
                {
                    queryable = queryable.Include(navProperty);
                }
            }
            return queryable;
        }
    }
}
