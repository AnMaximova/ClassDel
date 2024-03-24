using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDel
{
    public abstract class Access<T>
    {
        public abstract T Input_Value();
        public abstract T Random_Value();
        public abstract string ValueToString(T val);
    }
}
