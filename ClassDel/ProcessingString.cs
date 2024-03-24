using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDel
{
    public class ProcessingString : Access<string>
    {
        private string n;
        public ProcessingString()
        {
            n = "";
        }
        public override string Input_Value()
        {
            n = Console.ReadLine();
            return n;
        }

        public override string Random_Value()
        {
            Random rnd = new Random();
            int len = rnd.Next(3, 8);
            char[] chars = new char[len];
            for (int i = 0; i < len; i++)
            {
                int num = rnd.Next(33, 256);
                chars[i] = (char)num;
            }
            string str = new string(chars);
            return str;
        }
        public override string ValueToString(string val)
        {
            return val;
        }
    }
}
