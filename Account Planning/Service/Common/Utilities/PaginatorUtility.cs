using System.Linq;

namespace Com.ACSCorp.AccountPlanning.Service.Common.Utilities
{
    public static class PaginatorUtility<T> where T : class
    {
        private static IQueryable<T> ApplyPaging(IQueryable<T> query, int pageNumber, int pageSize)
        {
            if (pageNumber < 0 || pageSize <= 0)
            {
                return query;
            }

            query = query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize);

            return query;
        }
    }
}