using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServices.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;       
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public string GetResposta () {


            return "Implementado";
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public bool SaveChangs()
        {
            //se o contexto for maior que zero retorna true
          return (_context.SaveChanges() > 0);
        }
    }
}
