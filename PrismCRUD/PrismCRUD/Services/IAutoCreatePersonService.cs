using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCRUD.Services
{
    public interface IAutoCreatePersonService
    {
        Task startAsync();

        Task cancelAsync();

        bool IsStarted();
    }
}
