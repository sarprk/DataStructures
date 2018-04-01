using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Graph
{
    class GraphBFS : Graph
    {
        public GraphBFS(int vertices) : base(vertices)
        {

        }

        public override void PrintGraph(int vertex = 0)
        {
            HashSet<int> visited = new HashSet<int>();
            Stack<int> stackedItem = new Stack<int>();
            stackedItem.Push(vertex);
            visited.Add(vertex);
            while (stackedItem.Count > 0)
            {
                vertex = stackedItem.Pop();
                Write(vertex + " - Head");
                foreach (var item in adjacencyList[vertex])
                {
                    if (!visited.Contains(item) && vertex != item)
                    {
                        stackedItem.Push(item);
                        visited.Add(item);
                        Write("-> " + item);
                    }
                    
                }
                WriteLine();
            }
        }
    }
}
