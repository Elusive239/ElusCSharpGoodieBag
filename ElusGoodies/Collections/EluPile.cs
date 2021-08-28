using System;

namespace ElusGoodies.Collections
{
    public class EluPile<T> : IEnumerator, IEnumerable where T : class, IEquatable<T>, IPileable {
        public int Count{get;set;}
        public T[] items;
        public EluPile(){
            items = new T[10];
            Count = 0;
        }
        public EluPile(int size){
            items = new T[size];
            Count = 0;
        }

        public bool Add(T item){
            if(Count > 0)
            foreach (T t in this)
            {
                if(t.Equals(item)){
                    t.itemAmount++;
                    return true;
                }
            }

            if(Count == items.Length){
                return false;
            }
    
            items[Count] = item;
            Count++;
        }

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

        /// <summary>Get or Set an item in the list.</summary>
        public T this[int index]{ 
            get{
                return this.items[index];
            }
            set{
                this.items[index] = value;
            } 
        }
    }
    public interface IPileable{
        int itemAmount{get;set;}
    }
}