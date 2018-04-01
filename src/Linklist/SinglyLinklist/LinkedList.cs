using System;
using System.Collections;
using System.Collections.Generic;

namespace SinglyLinklist
{
    public class LinkedList<T> : ICollection<T>
    {

        //Head
        public LinkedListNode<T> Head { get; private set; }

        //Tail
        public LinkedListNode<T> Tail { get; private set; }

        #region --Add
        public void AddFirst(T value)
        {
            AddFirst(new LinkedListNode<T>(value));
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            LinkedListNode<T> temp = Head;
            Head = node;
            if (Count == 0)
            {
                Head = node;
                Tail = node;
            }

            Head.Next = temp;
            Count++;
        }

        public void AddLast(T value)
        {
            AddLast(new LinkedListNode<T>(value));
        }

        public void AddLast(LinkedListNode<T> node)
        {
            LinkedListNode<T> temp = Tail;
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                temp.Next = node;
            }

            Tail = node;
            Count--;
        }
        #endregion

        #region --Remove
        public void RemoveFirst()
        {
            if (Count > 0)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    Head = Head.Next;
                }
                Count--;
            }
        }

        public void RemoveTail()
        {
            if (Count > 0)
            {
                if (Count == 1)
                {
                    Tail = Head = null;
                }
                else
                {
                    LinkedListNode<T> temp = Head;
                    while (temp.Next != Tail)
                    {
                        temp = temp.Next;
                    }
                    temp.Next = null;
                    Tail = temp;
                }
                Count--;
            }


        }
        #endregion

        #region --ICollection
        public int Count
        {
            get;
            private set;
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            AddFirst(item);
        }

        public void Clear()
        {
            Tail = null;
            Head = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((System.Collections.Generic.IEnumerable<T>)this).GetEnumerator();
        }

        #endregion
    }
}
