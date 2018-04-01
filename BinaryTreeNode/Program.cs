using static System.Console;
using System;
namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<string> tree = new BinaryTree<string>();
            string input = string.Empty;
            input = ReadLine();
            while (!input.Equals("quit"))
            {
                foreach (var item in input.Split(' '))
                {
                    tree.Add(item);
                }
                input = ReadLine();
            }

            //WriteLine("Tree creation completed!!");
            //WriteLine("\n\nPreOrder: Tree traversal started!!");
            //tree.PreOrderTraversal((value) => { WriteLine(value); });

            WriteLine("\n\nInorder: Tree traversal started!!");
            tree.InOrderTraversal((value) => { WriteLine(value); });

            //WriteLine("\n\nPost Order: Tree traversal started!!");
            //tree.PostOrderTraversal((value) => { WriteLine(value); });

            //foreach (var item in tree)
            //{
            //    Write(item);
            //}
            WriteLine("Does tree contains 'This'");
            Write(tree.Contains("This"));
            ReadKey();
            WriteLine("Removing This");
            tree.Remove("This");
            tree.Remove("This");
            WriteLine("After removing This");
            WriteLine("\n\nInorder: Tree traversal started!!");
            tree.InOrderTraversal((value) => { WriteLine(value); });

            Read();
        }
    }
}
