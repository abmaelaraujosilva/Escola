using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.DataSource
{
    public interface IConnection
    {
        bool ExecuteNonQuery(string sql);
        DataTable List(string sql);
    }
}
