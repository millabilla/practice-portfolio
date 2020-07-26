using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_460
{
   public class LinkedQueue<T> : IQueueInterface<T> {

        private Node<T> Front { get; set; }
        private Node<T> Rear { get; set; }

        public LinkedQueue() {
            Front = null;
            Rear = null;
        }

        public T Push (T element) {
            if (element == null) {
                throw new NullReferenceException();
            }

            if (IsEmpty()) {
                Node<T> temp = new Node<T>(element, null);
                Rear = temp;
                Front = temp;
            }

            else {
                Node<T> temp = new Node<T>(element, null);
                Rear.next = temp;
                Rear = temp;
            }
            return element;
        }
        
        public T Pop() {
            T temp = default(T);

            if (IsEmpty()) {
                throw new QueueUnderflowException("The queue was empty when pop was invoked.");
            }

            else if (Front == Rear) {
                temp = Front.data;
                Front = null;
                Rear = null;
            }

            else {
                temp = Front.data;
                Front = Front.next;
            }

            return temp;
        }

        public T Peek() {
            if (IsEmpty()) {
                throw new QueueUnderflowException("The queue was empty when peek was invoked.");
            }

            return Front.data;
        }

        public bool IsEmpty() {
            if (Front == null && Rear == null) {
                return true;
            }

            else {
                return false;
            }
        }
   }
}
