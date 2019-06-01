using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Repository
{
    public interface IMapper<T>
    {
        T MapperFromDataSource(DataRow DR);
        List<T> MapperAllFromDataSource(DataTable DT);
    }
}
