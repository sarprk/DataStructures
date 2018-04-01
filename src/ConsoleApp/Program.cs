using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using static System.Console;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Node first = new Node { Value = 1 };
            Node middle = new Node { Value = 2 };
            Node last = new Node { Value = 3 };

            first.Next = middle;
            middle.Next = last;
            PrintList(first);
            ReadLine();
        }

        public static void PrintList(Node node)
        {
            while(node!=null)
            {
                WriteLine(node.Value);
                node = node.Next;
            }
        }
    }
}
