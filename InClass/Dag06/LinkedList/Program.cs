using System;

namespace Undervisningsgang6.Eks3.a
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new LinkedList();
            x.AddFirst("Test");
            x.AddFirst("Test2");
            x.AddFirst("Test3");
            x.AddFirst("Test4");
            x.AddFirst("Test5");

            x.ReplaceAt(3, "new value");

            Console.WriteLine(x.Get(0));
            Console.WriteLine(x.Get(1));
            Console.WriteLine(x.Get(2));
            Console.WriteLine(x.Get(3));
            Console.WriteLine(x.Get(4));
        }
    }


    public class LinkedList
    {

        // embedded class !
        public class LinkedListItem
        {
            private object data;
            private LinkedListItem next;

            public LinkedListItem(object data, LinkedListItem next)
            {
                this.data = data;
                this.next = next;
            }

            public object GetData()
            {
                return this.data;
            }

            public LinkedListItem GetNext()
            {
                return this.next;
            }
        }

        private LinkedListItem head;

        public LinkedList()
        {
        }
        public void AddFirst(object o)
        {
            var newItem = new LinkedListItem(o, head);
            head = newItem;
        }
        public void RemoveFirst()
        {
            head = head.GetNext();
        }
        public object Get(int i)
        {
            var item = head;
            for (int j = 0; j < i; j++)
            {
                if (item.GetNext() == null)
                    throw new IndexOutOfRangeException();
                item = item.GetNext();
            }
            return item.GetData();
        }

        // ReplaceAt(int index, Object o)
        // iterate over list until at target index (Get(index))
        // replace data-payload at position
        public void ReplaceAt(int index, Object o)
        {
            // get element before index (A), 
            // get element after index (B)
            // modify that header(A) to point to new element
            // point new element-next to (B)
        }

        // AddAt(int index, Object o)
        // copy all elements after index to index+1
        // add new element at index-position

        // RemoveAt(index i)
        // copy all elements from index+1 to to index-1

        // Clear
        // delete all elements
    }
}
