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
        /// <summary>
        /// Returns true if the item is added to the list.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Add(T item){
            if(Contains(item))
            foreach (T t in this)
            {
                if(t.Equals(item) && (t.itemAmount  < t.itemCapacity || t.itemCapacity == NaN)){
                    t.itemAmount+=item.itemAmount;
                    return true;
                }
            }

            if(Count == items.Length){
                return false;
            }
    
            items[Count] = item;
            Count++;    
        }
        /// <summary>
        /// Returns true if the provided item is in the list
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item){
            if(Count <= 0) return false;
            return GetIndex(item) != -1;
        }

        /// <summary>Removes an item from the list at the specified index.</summary>
        public void Remove(int i){
            for(int x = i; x < Count;x++){
                if(x+1 != Count){
                    items[x] = items[x+1];
                }
            }
            Count --;
        }

        /// <summary>Removes the specified item from the list.</summary>
        public void Remove(T item){
            int i = GetIndex(item);
            for(int x = i; x < Count;x++){
                if(x+1 != Count){
                    items[x] = items[x+1];
                }
            }
            Count --;
        }
        /// <summary>
        /// Removes an amount of an item from the item in the list.
        /// returns false if the item is not within the list or the
        /// amount you are attempting to remove is greater than the 
        /// amount the item has.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool RemoveAmount(T item, int amount){
            int index = GetIndex(item);
            if(index == -1) return false;

            if(item.itemAmount - amount < 1) return false;

            items[index].itemAmount -= amount;

        }

        public int GetIndex(T item){
            for(int i = 0; i < Count; i++){
                if(items[i].Equals(item)){
                    return i;
                }
            }
            return -1;
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

        /// <summary>
        /// Removes items from the list if they're itemAmount is == 0
        /// </summary>
        public void UpdateItem(T item){            
        int index = GetIndex(item);
            if(index == -1) return;

            if(items[index].itemAmount < 1)
                Remove(index);
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