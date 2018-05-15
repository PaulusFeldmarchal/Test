using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminServer.Domain.Interfaces
{
    interface ITestService<TModel> : IDisposable where TModel : class
    {
        IList<TModel> GetAll();
        TModel Get(int id);
        void Save(TModel model);
        void Delete(int id);
    }
}
