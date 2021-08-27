using System;
using System.Collections;

namespace ElusGoodies.Collections
{
    public  class EluList<T> : IEnumerator,IEnumerable where T : class, IEquatable<T> {
        T[] items;
        int position = -1;
        /// <summary>Returns the amount of items in the list.</summary>
        public int Count {get; set;}
        /// <summary>Returns the lists total size</summary>
        public int Size {get {return items.Length;}}
        /// <summary>Shorthand for Count <= 0</summary>
        public bool isEmpty { get { return Count <= 0; } }
        
        /// <summary>Creates a new list of items with the default size of 10.</summary>
        public EluList(){
            items = new T[10];
            Count = 0;
        }

        /// <summary>Creates a new list of items with the specified size.</summary>
        public EluList(int size){
            items = new T[size];
            Count = 0;
        }

        /// <summary>Creates a new list of items with the specified array.</summary>
        public EluList(T[] items){
            this.items = items;
            Count = 0;
            foreach (T item in items)
            {
                Count++;
            }
        }

        /// <summary>Adds a new item to the list.</summary>
        public void Add(T item){
            if(Count == items.Length){
                this.ExpandList(10);
            }
            items[Count] = item;
            Count++;
        }

        /// <summary>Removes an item from the list at the specified index.</summary>
        public void Remove(int i){
            for(int x = i; x < Count;x++){
                if(x+1 != Count)
                    items[x] = items[x+1];
            }
            Count --;
        }

        /// <summary>Removes a specified item from the list.</summary>
        public void Remove(T i){

            for(int x = 0; x < Count;x++){
                if(items[x] == i)
                    if(x+1 != Count){
                        Remove(x);
                        return;
                    }
            }
            
        }

        /// <summary>Increases the size of the list by a provided amount.</summary>
        public void ExpandList(int amount){
            T[] newList = new T[items.Length + amount];
            int index = 0;
            foreach (T item in items)
            {
                newList[index] = item;
                index++;
            }
            items = newList;
        }
        /// <summary>Get or Set an item in the list.</summary>
        public T this[int index]{ 
            //Then do whatever you need to return/set here.
            get{
                return this.items[index];
            }
            set{
                this.items[index] = value;
            } 
        }

        /// <summary>Combines two seperate lists of the same item into one big one.</summary>
        public EluList<T> CombinedList(EluList<T> other){
            int size = Count + other.Count;
            T[] allItems = new T[size];
            int index = 0;
            foreach (T item in items)
            {
                allItems[index] = item;
                index++;
            }
            foreach (T item in other.items)
            {
                allItems[index] = item;
                index++;
            }
            return new EluList<T>(allItems);
        }

        /// <summary>Checks if an item is in the list.</summary>
        public bool Contains(T itemToFind) {
            foreach (T item in items)
            {
                if(item.Equals( itemToFind)) return true;
            }
            return false;
        }

        /// <summary>Removes empty spaces in the list.</summary>
        public void Trim(){
            T[] allItems = new T[Count ];
            for (int i = 0; i < Count; i++)
            {
                allItems[i] = items[i];
            }
            items = allItems;
        }

        /// <summary>Returns all of the items in the list as a Read-Only array.</summary>
        public T[] Items {get {return items;}} 
        
        /// <summary>For printing the current item Count and Size of the list</summary>
        public override string ToString() => "Count: " + Count +", Size: "+Size;


        //IEnumerator and IEnumerable require these methods.
       public IEnumerator GetEnumerator()
       {
           return (IEnumerator)this;
       }
       //IEnumerator
       public bool MoveNext()
       {
           position++;
           return (position < items.Length);
       }
       //IEnumerable
       public void Reset()
       {
           position = 0;
       }
       //IEnumerable
       public object Current
       {
           get { return items[position];}
       }
    }   
}