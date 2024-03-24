using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDel
{
    public abstract class HeirArray<T>
    {
        public HeirArray(Access<T> item, bool input_mode = false)
        {
            if (input_mode)
            {
                InputUser(item);
            }
            else
            {
                InputRandom(item);
            }
        }
        protected abstract void InputUser(Access<T> item);
        protected abstract void InputRandom(Access<T> item);
        public abstract void Print();
    }
}
