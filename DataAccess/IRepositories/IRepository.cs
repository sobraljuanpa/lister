using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepositories
{
    internal interface IRepository<T>
    {
        public T Get(int id);
        public IQueryable<T> GetAll();
        public void Add(T entity);
        public void Delete(int id);
        public void Update(int id, T entity);
    }
}
