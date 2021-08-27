using System;
//using System.Collections;

namespace ElusGoodies.Collections
{
    //https://youtu.be/3Dw5d7PlcTM
    //Entirely from Sebastian Lague, he's awesome
    //This will never be used unless I want to implement A* pathfinding somewhere
    //Because it makes pathfinding go FAST
    public class EluHeap<T> where T : IHeapItem<T>{
        T[] items;
        int count = 0;

        public EluHeap(int size){
            items = new T[size];
        }

        public void Add(T item){
            item.heapIndex = count;
            items[count] = item;
            SortUp(item);
            count++;
        }

        public T RemoveFirst(){
            T firstItem = items[0];
            items[0] = items[count];
            items[0].heapIndex = 0;
            SortDown(items[0]);
            return firstItem;
        }

        public bool Contains(T item){
            return Equals(items[item.heapIndex], item);
        }

        public void UpdateItem(T item){
            SortUp(item);
        }

        public int Count{get{ return count;}}

        void SortUp(T item){
            int parentIndex = (item.heapIndex  -1) / 2 ;
            while (true)
            {
                T parentItem = items[parentIndex];
                if(item.CompareTo(parentItem) > 0){
                    Swap(item, parentItem);
                }else{
                    break;
                }
            }
        }

        void SortDown(T item){
            while (true)
            {
                int childIndexLeft = item.heapIndex * 2 + 1;
                int childIndexRight = item.heapIndex * 2 + 2;
                int swapIndex = 0;

                if(childIndexLeft < count){
                    swapIndex = childIndexLeft;
                    if(childIndexRight < count){
                        if(items[childIndexLeft].CompareTo(items[childIndexRight]) < 0){
                            swapIndex = childIndexRight;
                        }
                    }
                    if(item.CompareTo(items[swapIndex]) < 0){
                    Swap(item, items[swapIndex]);
                    }else{
                        return;
                    }
                }else{
                    return;
                }
            }  
        }

        void Swap(T itemA, T itemB){
            items[itemA.heapIndex] = itemB;
            items[itemB.heapIndex] = itemA;
            int temp = itemA.heapIndex;
            itemA.heapIndex = itemB.heapIndex;
            itemB.heapIndex = temp; 
        }

        public T this[int index]{ 
            //Then do whatever you need to return/set here.
            get{
                return this.items[index];
            }
            set{
                this.items[index] = value;
            } 
        }
    }
    public interface IHeapItem<T> : IComparable<T>
    {
        int heapIndex{get; set;}
    }
}