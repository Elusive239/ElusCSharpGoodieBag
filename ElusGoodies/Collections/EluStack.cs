using System;

namespace ElusGoodies.Collections
{
    public class EluStack<T> where T : IEquatable<T> {
        T[] stack;
        int count = 0;
        public int Count{get {return count;}}

        public EluStack(){
            stack = new T[10];
        }

        public EluStack(int size){
            stack = new T[size];
        }

        public bool Push(T item){
            try{
                stack[count] = item;
            }catch{
                Console.Log("Stack is full!");
                return false;
            }
            count ++;
            return true;
        }

        public T Peek(){
            return stack[count-1];
        }

        public T Pop(){
            count --;
            return stack[count]; 
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