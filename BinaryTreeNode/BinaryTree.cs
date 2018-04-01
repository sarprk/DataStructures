using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private BinaryTreeNode<T> head;
        public int Count { get; private set; }
        #region Add
        public void Add(T value)
        {
            //count =0 , then head
            if (Count == 0)
            {
                head = new BinaryTreeNode<T>(value);
                Count++;
            }
            else
            {
                AddTo(head, value);
                Count++;
            }
            //count >0 then compare and add left or right

        }
        private void AddTo(BinaryTreeNode<T> node, T value)
        {

            var result = node.CompareTo(value);
            if (result > 0)
            {
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(value);
                }
                else
                    AddTo(node.Left, value);
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>(value);
                }
                else
                    AddTo(node.Right, value);
            }

        }

        #endregion

        #region Traversals
        public void PreOrderTraversal(Action<T> action)
        {
            PreOrderTraversal(action, head);
        }
        private void PreOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                action(node.Value);
                PreOrderTraversal(action, node.Left);
                PreOrderTraversal(action, node.Right);
            }
        }

        public void InOrderTraversal(Action<T> action)
        {
            InOrderTraversal(action, head);
        }

        private void InOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                InOrderTraversal(action, node.Left);
                action(node.Value);
                InOrderTraversal(action, node.Right);
            }
        }

        public void PostOrderTraversal(Action<T> action)
        {
            PostOrderTraversal(action, head);
        }
        private void PostOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                PostOrderTraversal(action, node.Left);
                PostOrderTraversal(action, node.Right);
                action(node.Value);
            }
        }
        #endregion
        public bool Contains(T value)
        {
            BinaryTreeNode<T> parent;
            return FindWithParent(value, out parent) != null;
        }
        private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T> node = head;
            parent = null;

            if (node != null)
            {
                while (node != null)
                {
                    if (node.CompareTo(value) > 0)
                    {
                        node = node.Left;
                        // Visit left
                    }
                    else if (node.CompareTo(value) < 0)
                    {
                        node = node.Right;
                        //Visit right
                    }
                    else
                    {
                        //found
                        break;
                    }
                    parent = node;

                }
            }
            return node;
        }
        public IEnumerator<T> InOrderTraversal()
        {
            //check for head
            // take a stack of binary node
            //start pushing node to stack 
            //until node are not null to left

            if (head != null)
            {
                Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
                BinaryTreeNode<T> current = head;
                bool goLeftNext = true;

                stack.Push(current);
                while (stack.Count > 1)
                {
                    if (goLeftNext)
                    {
                        while (current.Left != null)
                        {
                            current = current.Left;
                            stack.Push(current);
                        }
                    }

                    yield return current.Value;

                    if (current.Right != null)
                    {
                        current = current.Right;
                        goLeftNext = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Remove(T value)
        {
            BinaryTreeNode<T> parent;
            BinaryTreeNode<T> node = FindWithParent(value, out parent);

            if (node == null)
            {
                return false;
            }
            else
            {
                Count--;
                #region case 1: When node does not have right child
                if (node.Right == null)
                {
                    //node left will replace the current node
                    if (parent == null)
                    {
                        head = node.Left;
                    }
                    else
                    {
                        var result = parent.CompareTo(node.Value);
                        if (result > 0)
                            parent.Left = node.Left;
                        else
                            parent.Right = node.Left;
                    }
                }
                #endregion

                #region case 2: When node has right child and node.right.left is null
                else if (node.Right.Left == null)
                {
                    node.Right.Left = node.Left;
                    if (parent == null)
                    {
                        head = node.Right;
                    }
                    else
                    {
                        var result = parent.CompareTo(node.Right.Value);
                        if (result > 0)
                            parent.Left = node.Right;
                        else
                            parent.Left = node.Right;
                    }
                }
                #endregion

                #region case 3: When node has right child and node.right.left is not null
                else
                {
                    BinaryTreeNode<T> leftMost = node.Right.Left;
                    BinaryTreeNode<T> leftMostParent = node.Right;

                    while (leftMost.Left != null)
                    {
                        leftMostParent = leftMost;
                        leftMost = leftMost.Left;
                    }
                    //Take care of leftmost right child
                    leftMostParent.Left = leftMost.Right;
                    leftMost.Right = node.Right;
                    leftMost.Left = node.Left;

                    if (parent == null)
                    {
                        head = leftMost;
                    }
                    else
                    {
                        var result = parent.CompareTo(leftMost.Value);
                        if (result > 0)
                        {
                            parent.Left = leftMost;
                        }
                        else
                            parent.Right = leftMost;
                    }
                }
                #endregion
            }
            return true;

        }
    }
}
