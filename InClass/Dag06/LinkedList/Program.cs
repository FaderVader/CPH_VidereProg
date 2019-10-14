using System;

namespace Undervisningsgang6.Eks3.a
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new LinkedList();
            x.AddFirst("First0");

            x.AddLast("Last1");
            x.AddLast("Last2");
            x.AddLast("Last3");
            x.AddLast("Last4");

            //x.AddFirst("First2");
            //x.AddFirst("First3");
            //x.AddFirst("First4");
            //x.AddFirst("First5");

            x.AddLast("AddedToLast5");

            x.ReplaceAt(2, "replacedValueAt2");

            x.AddAt(7, "addedat6");

            x.PrintAll();

            Console.ReadKey();
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
            
            public void ModifyNext(LinkedListItem next) 
            {
                this.next = next;
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
        public void AddLast(object o)
        {
            var currentItem = head;
            while (currentItem.GetNext() != null)
            {                
                currentItem = currentItem.GetNext();
            }
            currentItem.ModifyNext(new LinkedListItem(o, null));
        }
        public void RemoveFirst()
        {
            head = head.GetNext();
        }
        
        public object Get(int index)
        {
            var item = head;
            for (int j = 0; j < index; j++)
            {
                if (item.GetNext() == null)
                    return null; //throw new IndexOutOfRangeException();
                item = item.GetNext();
            }
            return item.GetData();
        }

        public void ReplaceAt(int requestedIndex, Object o)
        {
            LinkedListItem previous = head;
            LinkedListItem current = head;
            LinkedListItem next = head;

            int indexer = 0;

            // TODO: throw index-out-of-range exception if next is null
            //if (current == null) { throw new IndexOutOfRangeException(); }  
            while (next.GetNext() != null)
            {
                if (indexer == requestedIndex)
                {
                    next = current.GetNext();  
                    var newItem = new LinkedListItem(o, next);
                    previous.ModifyNext(newItem);

                    if (indexer==0) { head = newItem; }
                    return;
                }

                // keep iterating
                indexer++;
                previous = current;
                current = current.GetNext();
                next = current.GetNext();
            }
        }

        public void AddAt(int index, object o)
        {
            if (index == 0) // handle edge-case
            {
                AddFirst(o);
                return;
            }

            LinkedListItem previous = head;
            LinkedListItem current = head;
            int indexer = 0;

            while (true)  // current.GetNext() != null
            {
                if (indexer == index)
                {
                    var newItem = new LinkedListItem(o, current);
                    previous.ModifyNext(newItem);
                    return;
                }

                indexer++;
                previous = current;
                current = current.GetNext();
            }
        }

        // RemoveAt(index i)
        // copy all elements from index+1 to to index-1

        // Clear
        // delete all elements

        public void PrintAll()
        {
            var currentItem = head;
            while (currentItem != null)
            {
                Console.WriteLine(currentItem.GetData());
                currentItem = currentItem.GetNext();
            }
        }
    }
}
