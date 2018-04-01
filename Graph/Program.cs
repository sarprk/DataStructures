using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphBFS graph = new GraphBFS(4);
            graph.AddEdge(0, 1, true);
            graph.AddEdge(0, 2, true);

            graph.AddEdge(1, 2, true);

            graph.AddEdge(2, 0, true);
            graph.AddEdge(2, 3, true);

            graph.AddEdge(3, 3, true);
            graph.PrintGraph(2);
            ReadLine();
        }
    }


}
