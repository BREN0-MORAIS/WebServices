using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServices.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChangs();

    }
}
