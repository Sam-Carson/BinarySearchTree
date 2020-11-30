using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace BinarySearchTreeRecursive
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree t = new BinarySearchTree();
            string keyInput;
            string valueInput;
            string input;
            bool done = false;

            //UNCOMMENT THE LINES TO START WITH A PREPOPULATED TREE
            //"keysInInsertionOrder" allows you to see how the shape of the tree is different
            //when the order of insertion changes.
            //List<int> keysInInsertionOrder = new List<int> { 50, 72, 17, 12, 23, 54, 76, 9, 14, 19 };
            //for (int i = 0; i < keysInInsertionOrder.Count; i++)
            //{
            //    t.Insert(keysInInsertionOrder[i]);
            //}
            //t.Visualize();
            //WriteLine("\nKeys were entered in this order: \n" + String.Join(" ", keysInInsertionOrder));
            //WriteLine("\nContent of binary tree in ascending sequence: ");
            //t.Traverse();
            //WriteLine();
            //END START WITH A PREPOPULATED TREE


            //UNCOMMENT THIS STATEMENT TO START WITH AN EMPTY TREE
            ////"keysInInsertionOrder" allows you to see how the shape of the tree is different
            ////when the order of insertion changes.
            //List<int> keysInInsertionOrder = new List<int>();
            //END START WITH AN EMPTY TREE



            do
            {
                Write("\nSelect (I)nsert, (D)elete, (T)raverse, (F)ind, (O)rder of input, or (Q)uit: ");
                switch (ReadLine().ToUpper())
                {
                    case "I":
                        WriteLine("INSERT A NEW TEAM");
                        WriteLine("----------------------");
                        Write("\n- - - Team name: ");
                        keyInput = ReadLine();
                        Write("\n- - - Team city: ");
                        valueInput = ReadLine();
                        t.Insert(keyInput, valueInput);
                        //keysInInsertionOrder.Add(input);
                        t.Visualize();
                        break;
                    case "D":
                        Write("\nTeam to delete: ");
                        input = ReadLine();
                        t.Delete(input);
                        t.Visualize();
                        break;
                    case "T":
                        WriteLine("\nContent of binary tree in ascending sequence: ");
                        t.Traverse();
                        WriteLine();
                        break;
                    case "F":
                        Write("\nTeam to find: ");
                        input = ReadLine();
                        string message = t.Find(input) ? "found" : "not found";
                        WriteLine($"{input} was {message}");
                        break;
                    case "Q":
                        WriteLine("\nOkey dokey.  All done.");
                        done = true;
                        break;
                    default:
                        WriteLine("Invalid command.");
                        break;
                }
            } while (!done);

            ReadKey();
        }
    }
}
