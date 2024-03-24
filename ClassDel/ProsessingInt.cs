using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDel
{
    public class ProcessingInt : Access<int>
    {
        private int n;
        public ProcessingInt()
        {
            n = default(int);
        }
        public override int Input_Value()
        {
            n = int.Parse(Console.ReadLine());
            return n;
        }
        public override int Random_Value()
        {
            Random rnd = new Random();
            n = rnd.Next(-200, 201);
            return n;
        }
        public override string ValueToString(int val)
        {
            return val.ToString();
        }
    }
}
