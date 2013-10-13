using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulleOnline.Data.Contracts
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
