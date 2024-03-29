﻿using System;

namespace Undervisningsgang6.Eks2
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new ArrayList();
            x.AddLast("Test1");
            x.AddLast("Test2");
            x.AddLast("Test3");
            x.AddLast("Test4"); 
            x.AddLast("Test5");
            x.AddLast("Test6");
            x.AddLast("Test7");
            
            x.AddAt(3, "added");
            x.AddAt(7, "added2");
            x.PrintElements();

            x.ReplaceAt(3, "replaced");
            x.PrintElements();

            x.RemoveAt(3);
            x.RemoveAt(6);
            x.PrintElements();


            x.Clear();
            x.PrintElements();

            Console.ReadKey();
        }

    }

    public class ArrayList
    {
        private object[] array;
        private int elements;
        public ArrayList()
        {
            array = new object[4];
            elements = 0;
        }
        public object Get(int i)
        {

            return array[i];
        }

        
        public void AddLast(object o)
        {
            var newArray = ExpandArrayCheck();
            array.CopyTo(newArray, 0);
            array = newArray;

            array[elements] = o;
            elements++;
        }
        public void RemoveLast()
        {
            array[elements] = null;
            elements--;
        }
        public void ReplaceAt(int index, object o)
        {
            IndexCheck(index);
            array[index] = o;
        }
        public void AddAt(int index, object o)
        {
            IndexCheck(index);
            object[] newArray = ExpandArrayCheck();   
            array.CopyTo(newArray, 0);

            // insert the new element at the requested position
            newArray[index] = o;

            // copy the old array to the new, one position offset (+)
            for (int i = index + 1; i <= elements; i++)
            {
                newArray[i] = Get(i - 1);
            }
            elements++;

            array = newArray;

        }
        public void RemoveAt(int index)
        {
            object[] newArray = new object[array.Length];
            array.CopyTo(newArray, 0);

            for (int i = index; i <= elements; i++)
            {
                newArray[i] = Get(i + 1);
            }

            elements--;
            array = newArray;
        }
        public void Clear()
        {
            array = new object[4];
            elements = 4;
        }

        private object[] ExpandArrayCheck() 
        {
            // when there's no more space in the orig array - x2 it
            return ((elements + 1) >= array.Length) ? new object[array.Length * 2] : new object[array.Length];
        }
        public void IndexCheck(int index)
        {
            if (index >= elements)
                throw new IndexOutOfRangeException();
            if (index < 0)
                throw new IndexOutOfRangeException();
        }                
        public void PrintElements()
        {
            for (int i = 0; i < elements; i++)
            {
                Console.WriteLine($"{i}: {array[i]}");
            }
            Console.WriteLine("");
        }


    }
}
