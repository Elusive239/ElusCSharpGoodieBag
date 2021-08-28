using System;

namespace ElusGoodies.Collections{
    
    public class EluLinkedList<T> : IEnumerator,IEnumerable where T : class, IEquatable<T> {
        int position = -1;
        public int Count {get; set;}
        public bool isEmpty { get { return Count <= 0; } }

        EluNode<T> head;

        public EluLinkedList(){}
        public EluLinkedList(T item){
            head = new EluNode<T>(item);
            Count++;
        }

        public bool AddFirst(T item){
            EluNode<T> newHead = new EluNode<T>(item);
            newHead.next = head;
            head = newHead;
            Count++;
        }

        public bool AddLast(T item){
            if(head == null){
                head = new EluNode<T>(item);
                Count++;
                return true;
            }
                
            
            EluNode<T> current = head;
            do{
                if(current.next != null){
                    current = current.next;
                    continue;
                }else{
                    current.next = new EluNode<T>(item);
                    Count++;
                    return true;
                }
            }while(true);

            return false;
        }

        T Get(int index){
            EluNode<T> current = head;
            for(int i = 0; i <= index; i++){
                if(i == index) return current;
                current = current.next;
            }
            return NaN;
        }

        public void ReplaceAt(T item, int index){
            Node<T> replacement = new Node<T>(item);
            if(index == 0){
                replacement.next = head.next;
                head = replacement;
                return;
            }

            Node<T> beforeIndex = Get(index-1), atIndex = beforeIndex.next;
            
            beforeIndex.next = replacement;
            if(atIndex.next != null || atIndex.next != NaN){
                Node<T> afterIndex = atIndex.next;
                replacement.next = afterIndex;
            }                 
        }

        public bool Contains(T itemToFind) {
            for (int i = 0; i < Count; i++)
            {
                if(this[i].Equals( itemToFind)) return true;
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
           get { return Get(position);}
       }
       public T this[int index]{ 
            //Then do whatever you need to return/set here.
            get{
                return this.items[index];
            } set{
                this.items[index] = value;
            }
        }
    }

    class EluNode<T>{
        public EluNode<T> next;
        public T item;
        public EluNode(T _item){
            item = _item;
        }

        public EluNode(T _item, EluNode<T> _next){
            next = _next;
        }
    }
}