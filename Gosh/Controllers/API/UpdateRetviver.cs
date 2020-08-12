using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gosh.Controllers.API
{
    interface UpdateRetviver
    {
        Task<TweeterResponse[]> FetchUpdate(string account);
    }
}
