using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Repository
{
    interface IRepository<T>
    {
        bool ADD(T TIten);
        bool DELETE(T TIten);
        bool UPDATE(T TIten, int ID);
        T GETBYID(int ID);
        List<T> LIST();
    }
}
