using System;
using System.Collections.Generic;

namespace MyList
{
    public class GenericList<T>
        where T : IComparable
    {
        // Fields
        private const int DefaultSize = 20;

        private T[] elements;
        private int size;
        private int count;

        // Properties
        public T[] Elements
        {
            get { return this.elements; }
            set { this.elements = value; }
        }

        public int Size
        {
            get { return this.size; }
        }

        public int Count
        {
            get { return this.count; }
        }

        // Constructors
        public GenericList()
            : this(DefaultSize)
        {
        }

        public GenericList(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException("Incorrect size! Please enter size > 0.");
            }

            this.size = size;
            this.elements = new T[size];
        }

        // Methods
        public void Add(T input)
        {
            GrowSizeIfNeeded();

            this.elements[count] = input;
            count++;
        }

        public T this[int index]
        {
            get
            {
                if (index >= this.count || index < 0)       // You can't reach element which is not filled. To do that switch count with size.
                {
                    throw new IndexOutOfRangeException("Invalid index! The index can't be negative or larger than the count of elements.");
                }

                return elements[index];
            }
        }       // Indexer

        public void RemoveAtIndex(int index)
        {
            if (index >= this.count || index < 0)       // You can't remove element which is not filled. To do that switch count with size. (there will be no effect)
            {
                throw new IndexOutOfRangeException("Invalid index! The index can't be negative or larger than the count of elements.");
            }

            for (int i = index; i < this.elements.Length - 1; i++)
            {
                elements[i] = elements[i + 1];
            }

            this.count--;
        }

        public void InsertAtIndex(int index, T input)
        {
            if (index >= this.count || index < 0)       // You can't remove element which is not filled. To do that switch count with size. (there will be no effect)
            {
                throw new IndexOutOfRangeException("Invalid index! The index can't be negative or larger than the count minus one of elements.");
            }

            // If after adding 1 element we are out of the range, it will autogrow.
            if (this.count + 1 >= this.size)
            {
                AutoGrow();
            }

            for (int i = index; i < this.elements.Length; i++)
            {
                T currElement = elements[i];

                elements[i] = input;

                input = currElement;
            }
        }

        public void Clear()
        {
            // The size will remain the same
            this.elements = new T[size];
            this.count = 0;
        }

        // This method will get all indexes with certain value and will add them to a list of integers.
        public List<int> GetIndexesByValue(T value)
        {
            List<int> positions = new List<int>();

            for (int i = 0; i < elements.Length; i++)
            {
                if (value.CompareTo(elements[i]) == 0)
                {
                    positions.Add(i);
                }
            }

            return positions;
        }

        public override string ToString()
        {
            string result = string.Empty;

            for (int i = 0; i < this.count; i++)
            {
                result += this.elements[i] + "\n";
            }

            return result;
        }

        // Autogrow methods
        private bool ListIsFull()
        {
            return this.count >= this.size;
        }

        private void AutoGrow()
        {
            this.size *= 2;
            T[] tempArr = elements;
            elements = new T[this.size];

            for (int i = 0; i < tempArr.Length; i++)
            {
                elements[i] = tempArr[i];
            }

            GC.Collect();
        }

        private void GrowSizeIfNeeded()
        {
            if (ListIsFull())
            {
                AutoGrow();
            }
        }

        // Generic methods
        public T Min()
        {
            T minimal = this.elements[0];

            for (int i = 1; i < this.Count; i++)
            {
                if (minimal > (dynamic)this.elements[i])
                {
                    minimal = this.elements[i];
                }                    
            }

            return minimal;
        }

        public T Max()
        {
            T maximal = this.elements[0];

            for (int i = 1; i < this.Count; i++)
            {
                if (maximal < (dynamic)this.elements[i])
                {
                    maximal = this.elements[i];
                }
            }                   

            return maximal;
        }
    }
}