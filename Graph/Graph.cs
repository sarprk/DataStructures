using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Graph
{
    class Graph
    {
        public int Vertices { get; set; }
        protected LinkedList<int>[] adjacencyList;
        public Graph(int vertices)
        {
            Vertices = vertices;
            adjacencyList = new LinkedList<int>[Vertices];
            //Intializes adjacency list
            for (int count = 0; count < vertices; count++)
            {
                adjacencyList[count] = new LinkedList<int>();
            }
        }
        public void AddEdge(int source, int destination, bool directed = false)
        {
            this.adjacencyList[source].AddLast(destination);
            if (!directed)
                this.adjacencyList[destination].AddLast(source);
        }

        public virtual void PrintGraph(int vertex = 0)
        {
            for (int i = 0; i < Vertices; i++)
            {
                Write(i + " - Head");

                foreach (var item in adjacencyList[i])
                {
                    Write(" -> " + item);
                }
                WriteLine();
            }
        }
    }
}
