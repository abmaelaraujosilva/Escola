using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Escola.Repository
{
    public abstract class MapperBase<T> : IMapper<T>
    {
        public  List<T> MapperAllFromDataSource(DataTable DT)
        {
            List<T> L = new List<T>();
            foreach (DataRow DR in DT.Rows)
            {
                L.Add(MapperFromDataSource(DR));
            }
            return L;
        }

        public abstract T MapperFromDataSource(DataRow DR);
    }
}