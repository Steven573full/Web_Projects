using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.BLL.Interfaces
{
    //De internal a publica
    public interface IRolService
    {
        //
        Task<List> Get(int id);
    }
}
