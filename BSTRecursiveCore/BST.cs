﻿using System;
using static System.Console;

namespace BinarySearchTreeRecursive
{
    public class BinarySearchTree
    {
        internal class Node
        {
            //For demo purposes, this node has only a key.  You can add a value
            //easily enough.

            public string Key;
            public string Value;
            public Node Left;
            public Node Right;
        }

        internal Node Root;

        public BinarySearchTree()
        {
            Root = null;
        }

        //Recursive Insert routine.  Public part starts at root and starts
        //the recursion to find the node after which to put the new node.

        public void Insert(string Key, string Value)
        {
            Root = Insert(Root, Key, Value);
        }

        // 48 minute mark in video
        private Node Insert(Node node, string key, string value)
        {
            if (node == null)           //We've gone past the end (or the tree is empty).
                                        //Now we can add a leaf!
            {
                node = new Node();
                node.Key = key;
                node.Value = value;
            }
            else if (key.CompareTo(node.Key) < 0)    //This new node belongs somewhere left of where we are
            {
                node.Left = Insert(node.Left, key, value);
            }
            else                         //Otherwise, it's gottta be somewhere right of where we are
            {
                node.Right = Insert(node.Right, key, value);
            }
            return node;
        }

        //Traversal in order is like magic.  Can you work out what's happening?
        public void Traverse()
        {
            Traverse(Root);
        }
        private void Traverse(Node node)
        {
            if (node == null) return;
            Traverse(node.Left);
            Write(node.Key + " ");
            Traverse(node.Right);
        }

        public void Delete(string key)
        {
            Root = Delete(Root, key);
        }

        private Node Delete(Node node, string key)
        {
            if (node == null) return node;

            if (key.CompareTo(node.Key) < 0)
            {
                node.Left = Delete(node.Left, key);
            }
            else if (key.CompareTo(node.Key) > 0)
            {
                node.Right = Delete(node.Right, key);
            }
            else
            {
                //Case where node has zero or one child.  Just delete it.
                if (node.Right == null)
                {
                    return node.Left;
                }
                else if (node.Left == null)
                {
                    return node.Right;
                }

                //For a node with two children, you replace the node being deleted with 
                //the largest node in its smaller (left) subtree.

                node.Key = MaxLeftChildValue(node.Left);

                node.Left = Delete(node.Left, node.Key);
            }

            return node;
        }


        //change maxVal to string an edited the method to return a string( og int)
        private string MaxLeftChildValue(Node node)
        {
            string maxVal = node.Key;
            while (node.Right != null)
            {
                maxVal = node.Right.Key;
                node = node.Right;
            }

            return maxVal;
        }

        public bool Find(string key)
        {
            return Find(Root, key);
        }

        private bool Find(Node node, string key)
        {
            if (node == null) return false;

            if (key == node.Key) return true;

            // if key is greater than node.key ??
            if (key.CompareTo(node.Key) > 0)
            {
                if (node.Right == null)
                {
                    return false;
                }
                else
                {
                    node = node.Right;
                    return Find(node, key);
                }
            }
            else
            {
                if (node.Left == null)
                {
                    return false;
                }
                else
                {
                    node = node.Left;
                    return Find(node, key);
                }
            }
        }

        //        /*****************************************************************************************************************
        //         * 
        //         *   CODE BELOW IS NOT PART OF THE BINARY SEARCH TREE PROPER
        //         *   
        //         *   This is visualization logic based on original code from Ivan Stoev via Stack Overflow.  Review it if you'd
        //         *   like, but it's not a fundamental part of the BST.  It's here only so you can see the result of your BST
        //         *   manipulation at run time more easily.
        //         * 
        //         * ***************************************************************************************************************/
        class NodeInfo
        {
            public Node Node;
            public string Text;
            public int StartPos;
            public int Size { get { return Text.Length; } }
            public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
            public NodeInfo Parent, Left, Right;
        }
        public void Visualize()
        {
            string textFormat = "0";
            int spacing = 1;
            int topMargin = 2;
            int leftMargin = 2;


            if (Root == null)
            {
                WriteLine("\n***Tree is empty***\n");
                return;
            }
            int RootTop = CursorTop + topMargin;
            var last = new System.Collections.Generic.List<NodeInfo>();
            var next = Root;
            for (int level = 0; next != null; level++)
            {
                var item = new NodeInfo() { Node = next, Text = next.Key };
                if (level < last.Count)
                {
                    item.StartPos = last[level].EndPos + spacing;
                    last[level] = item;
                }
                else
                {
                    item.StartPos = leftMargin;
                    last.Add(item);
                }
                if (level > 0)
                {
                    item.Parent = last[level - 1];
                    if (next == item.Parent.Node.Left)
                    {
                        item.Parent.Left = item;
                        item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos - 1);
                    }
                    else
                    {
                        item.Parent.Right = item;
                        item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos + 1);
                    }
                }
                next = next.Left ?? next.Right;
                for (; next == null; item = item.Parent)
                {
                    int top = RootTop + 2 * level;
                    Print(item.Text, top, item.StartPos);
                    if (item.Left != null)
                    {
                        Print("/", top + 1, item.Left.EndPos);
                        Print("_", top, item.Left.EndPos + 1, item.StartPos);
                    }
                    if (item.Right != null)
                    {
                        Print("_", top, item.EndPos, item.Right.StartPos - 1);
                        Print("\\", top + 1, item.Right.StartPos - 1);
                    }
                    if (--level < 0) break;
                    if (item == item.Parent.Left)
                    {
                        item.Parent.StartPos = item.EndPos + 1;
                        next = item.Parent.Node.Right;
                    }
                    else
                    {
                        if (item.Parent.Left == null)
                            item.Parent.EndPos = item.StartPos - 1;
                        else
                            item.Parent.StartPos += (item.StartPos - 1 - item.Parent.EndPos) / 2;
                    }
                }
            }
            SetCursorPosition(0, RootTop + 2 * last.Count - 1);
        }

        private void Print(string s, int top, int left, int right = -1)
        {
            SetCursorPosition(left, top);
            if (right < 0) right = left + s.Length;
            while (CursorLeft < right) Write(s);
        }
    }
}
