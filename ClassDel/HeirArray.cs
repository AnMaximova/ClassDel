using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDel
{
    public abstract class HeirArray<T> : IPrinter 
    {
        public HeirArray(int size)
        {
            Input(size);
            
        }
        protected abstract void Input(int size);
        public abstract void Print();
    }
}
