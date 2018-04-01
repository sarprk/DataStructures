using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linklist
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LinkedList<int> intList = new LinkedList<int>();
            intList.AddFirst(1);
            intList.AddLast(2);
            intList.AddLast(3);
            intList.AddFirst(4);

            foreach(var item in intList)
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }
    }
}
