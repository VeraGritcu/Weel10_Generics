using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class GenericList<T> where T : struct, IComparable
    {

        private T[] InternalArray { get; set; }
        private int size;
        private int countElementIdx;

        internal GenericList(int size)
        {
            this.size = size;
            this.InternalArray = new T[size];
            this.countElementIdx = 0;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 && index >= this.InternalArray.Length)
                {
                    throw new IndexOutOfRangeException("Cannot store more objects");
                }
                return this.InternalArray[index];

            }
            set
            {
                if (index < 0 && index >= this.InternalArray.Length)
                {
                    throw new IndexOutOfRangeException("Cannot store more objects");
                }
                this.InternalArray[index] = value;

            }

        }
        internal void Add(T param)
        {
            if (this.size > this.countElementIdx)
            {
                InternalArray[countElementIdx] = param;
                this.countElementIdx++;
            }
            else
            {
                Console.WriteLine("List is full");
            }
        }

        internal T GetByIndex(int index)
        {
            if (this.countElementIdx >= index)
            {
                return this.InternalArray[index];
            }

            throw new ArgumentException("Index inconsistency");
        }

        internal void RemoveByIndex(int index)
        {
            if (this.countElementIdx >= index)
            {
                this.InternalArray[index] = default(T);
            }
            else
            {
                throw new ArgumentException("Index inconsistency");
            }
        }

        internal void InsertValueAt(int index, T value)
        {
            if (this.countElementIdx >= index)
            {
                var existentValue = this.InternalArray[index];
                this.InternalArray[index] = value;
                Console.WriteLine("Value {0} removed and replaced by {1}", existentValue, value);

            }
            else
            {
                throw new ArgumentException("Index inconsistency");
            }
        }

        internal void ClearList()
        {
            for (int i = 0; i < InternalArray.Length; i++)
            {
                this.InternalArray[i] = default(T);
            }
        }

        internal bool FindElement(T value)
        {
            for (int i = 0; i < InternalArray.Length; i++)
            {
                if (InternalArray[i].Equals(value))
                {
                    return true;
                }
            }
            return false;
        }


        public override string ToString()
        {
            string result = null;
            foreach (var item in InternalArray)
            {
                result += $"[{item.ToString()}] ";
            }
            return result;

        }
        internal GenericList<T> AutoGrow()
        {
            var currentLength = 0;
            if (this.InternalArray[InternalArray.Length - 1].Equals(default(T)))
            {
                currentLength = this.InternalArray.Length;
            }

            var newArray = new GenericList<T>(currentLength * 2);

            for (int i = 0, j = 0; i < this.InternalArray.Length; i++, j++)
            {
                newArray.InternalArray[i] = this.InternalArray[j];
            }
            return newArray;
        }

        private static bool GetMin(T a1, T a2)
        {
            if (a1.CompareTo(a2) < 0)
            {
                return true;
            }
            else
                return false;
        }
        public T getArrayMin()
        {
            var min = this.InternalArray[0];
            for (var i = 1; i < this.size; i++)
            {
                if (GetMin(this.InternalArray[i], min))
                {
                    min = this.InternalArray[i];
                }
            }
            return min;
        }

        //MAX
        private static bool GetMax(T a1, T a2)
        {
            if (a1.CompareTo(a2) > 0)
            {
                return true;
            }
            else
                return false;
        }
        public T getArrayMax()
        {
            
            var max = this.InternalArray[0];
            for (var i = 1; i < this.size; i++)
            {
                if (GetMax(this.InternalArray[i], max))
                {
                    max = this.InternalArray[i];
                }
            }
            return max;
        }


    }
}
