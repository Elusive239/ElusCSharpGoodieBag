using System;

namespace ElusGoodies.Collections
{
    public class EluPile<T> : IEnumerator, IEnumerable where T :  IEquatable<T>, IPileable {
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
            if(Contains(item))
            foreach (T t in this)
            {
                if(t.Equals(item) && t.itemAmount  < t.itemCapacity){
                    t.itemAmount++;
                    return true;
                }
            }

            if(Count == items.Length){
                return false;
            }
    
            items[Count] = item;
            item.itemAmount++;
            Count++;    
        }

        public bool Contains(T item){
            if(Count <= 0) return false;

            foreach (T t in this)
            {
                if(t.Equals(item)){
                    return true;
                }
            }
            return false;
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
    /// <summary>
    /// Required to be implemented for an item to be put in a pile.
    /// </summary>
    public interface IPileable{
        /// <summary>
        /// Amount of the item you have
        /// </summary>
        /// <value></value>
        int itemAmount{get;set;}
        /// <summary>
        /// Amount of the item that you CAN have in this slot
        /// </summary>
        /// <value></value>
        int itemCapacity{get; set;}
    }
}