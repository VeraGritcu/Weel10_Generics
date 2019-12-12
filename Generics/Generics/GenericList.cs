﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
   internal class GenericList<T>
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
    }
}