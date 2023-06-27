using Microsoft.EntityFrameworkCore.Storage;

namespace Com.ACSCorp.AccountPlanning.Service.IRepository
{
    public interface IBaseRepository
    {
        public IDbContextTransaction BeginTransaction();
    }
}