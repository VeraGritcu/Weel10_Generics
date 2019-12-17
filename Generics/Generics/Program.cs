using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {

            GenericList<int> myList = new GenericList<int>(10);
            myList.Add(1);
            myList.Add(3);
            myList.Add(5);
            myList.Add(7);
            myList.Add(9);

            myList.Add(11);
            myList.Add(13);
            myList.Add(15);
            myList.Add(17);
            myList.Add(19);
            myList.Add(21);

            //var myElement = myList.GetByIndex(5);
           // Console.WriteLine(myElement);

            var min = myList.getArrayMin();
            Console.WriteLine(min);

            var max = myList.getArrayMax();
            Console.WriteLine(max);

            //myList.InsertValueAt(9, 20);

            //myList.ClearList();

            //var myString = myList.ToString();
            //Console.WriteLine(myString);

            Console.ReadKey();
        }
    }
}
