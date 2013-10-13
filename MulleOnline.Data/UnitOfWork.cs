using MulleOnline.Business.Entities;
using MulleOnline.Data.Contracts;
using MulleOnline.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulleOnline.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DbContext _context;

        public void Commit(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Context");
            }

            _context = context;
        }

        private GenericDataRepository<User> _userRepository;
        public GenericDataRepository<User> UserRepository 
        { 
            get 
            {
                if (_userRepository == null)
                {
                    _userRepository = new GenericDataRepository<User>(_context);
                }

                return _userRepository;
            } 
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
