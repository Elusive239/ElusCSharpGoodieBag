using System;

namespace ElusGoodies.Collections
{
    public class EluQueue<T> where T : IEquatable<T> {
        T[] queue;
        int count = 0;
        public int Count{get {return count;}}

        public EluQueue(){
            queue = new T[10];
        }

        public EluQueue(int size){
            queue = new T[size];
        }

        public bool Push(T item){
            try{
                if(queue.Length == count) 
                    return false;
            
                for (int i = count; i > 0; i++)
                {
                    queue[i] = queue[i+1];
                }

                queue[0] = item;
                count ++;
                return true;
            }catch{
                Console.Log("Stack is full!");
                return false;
            }
        }

        public T Peek() =>  queue[count-1];

        public T Pop(){
            count --;
            return queue[count]; 
        }

        public bool Contains(T item){
            if(IsEmpty){
                return false;
            }

            for(int i = 0; i < count; i++){
                if(item.Equals(item)){
                    return true;
                }
            }
            return false;
        }

        public bool IsEmpty => !(count > 0);
        
    }
}