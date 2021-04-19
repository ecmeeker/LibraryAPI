using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public interface ITransaction
    {
        Task CompleteAsync();
    }
}
