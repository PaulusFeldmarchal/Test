using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminServer.Domain.Interfaces
{
    interface ITestRepository <TEntity> : IDisposable where TEntity : class
    {
        IList<TEntity> GetAll();
        TEntity Get(int id);
        void Save(TEntity model);
        void Delete(int id);
    }
}
