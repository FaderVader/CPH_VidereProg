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
            x.AddLast("AddedToLast5");
            x.ReplaceAt(5, "replacedValueAt");
            x.AddAt(6, "addedatX");
            x.RemoveAt(6); 
            x.PrintAll();

            x.Clear();

            //x.ReplaceAt(0, "replced"); // should throw exception!
            x.AddLast("new list");
            x.PrintAll();

            Console.ReadKey();
        }
    }


    public class LinkedList
    {
        public class LinkedListItem   // embedded class !
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

        public void AddFirst(object o)
        {
            var newItem = new LinkedListItem(o, head);
            head = newItem;
        }
        public void AddLast(object o)
        {
            if (head == null) // guard clause
            {
                AddFirst(o);
                return;
            }

            var currentItem = head;
            while (currentItem.GetNext() != null)
            {
                currentItem = currentItem.GetNext();
            }
            currentItem.ModifyNext(new LinkedListItem(o, null));
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

            while (true)
            {
                if (indexer == index)
                {
                    var newItem = new LinkedListItem(o, current);
                    previous.ModifyNext(newItem);
                    return;
                }
                if (current == null) throw new IndexOutOfRangeException();

                indexer++;
                previous = current;
                current = current.GetNext();
            }
        }
        public void RemoveFirst()
        {
            if (head == null) throw new IndexOutOfRangeException();
            head = head.GetNext();
        }
        public void RemoveAt(int index) 
        {
            if (index == 0) // handle edge-case
            {
                RemoveFirst();
                return;
            }

            LinkedListItem previous = head;
            LinkedListItem current = head;
            LinkedListItem next;
            int indexer = 0;

            while (true)
            {
                if (indexer == index)
                {
                    next = current?.GetNext();
                    //next = current != null ? current.GetNext() : current;
                    //if (current != null) { next = current.GetNext(); } else { next = current; };
                    previous.ModifyNext(next);
                    return;
                }

                indexer++;
                previous = current;
                current = current.GetNext();

                if (current == null) throw new IndexOutOfRangeException();
            }
        }
        public void ReplaceAt(int requestedIndex, Object o)
        {
            LinkedListItem previous = head;
            LinkedListItem current = head;
            LinkedListItem next;

            int indexer = 0;

            while (true)
            {
                if (current == null) throw new IndexOutOfRangeException();

                if (indexer == requestedIndex)
                {
                    //next = current != null ? current.GetNext() : current;
                    next = current?.GetNext();
                    var newItem = new LinkedListItem(o, next);
                    previous.ModifyNext(newItem);

                    if (indexer == 0) { head = newItem; }
                    return;
                }

                indexer++;
                previous = current;
                current = current.GetNext();
            }
        }
        public void Clear()
        {
            head = null;
        }

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
