using System;
using System.Collections.Generic;
using System.Text;
using PAT.Common.Classes.Expressions.ExpressionClass;

//Note that the following classes are adapted from the in-built PAT library 
//classes found in PAT.Lib.Queue.cs and PAT.Lib.List.cs source code flies

//the namespace must be PAT.Lib, the class and method names can be arbitrary
namespace PAT.Lib
{
    public class Queue: ExpressionValue
    {
        public System.Collections.Generic.Queue<int> queue;
        
        //default constructor
        public Queue() 
        {
            this.queue = new System.Collections.Generic.Queue<int>();
        }
        
        public Queue(System.Collections.Generic.Queue<int> queue)
        {
            this.queue = new System.Collections.Generic.Queue<int>(queue);
        }

        //override
        public override ExpressionValue GetClone()
        {
 	         return new Queue(new System.Collections.Generic.Queue<int>(this.queue));
        }

        public override string ExpressionID
        {
            get
            {
                string returnString = "";
                foreach (int element in this.queue)
                {
                    returnString += element.ToString() + ",";
                }
                if (returnString.Length > 0)
                {
                    returnString = returnString.Substring(0, returnString.Length - 1);
                }

                return returnString;
            }
        }

        public override string ToString()
        {
            return "[" + ExpressionID + "]";
        }

        public int Count()
        {
            return this.queue.Count;
        }

        public void Enqueue(int element)
        {
            this.queue.Enqueue(element);
        }

        public int Dequeue()
        {
            if (this.queue.Count > 0)
            {
                return queue.Dequeue();
            }
            else
            {
                //throw PAT Runtime exception
                throw new RuntimeException("Access an empty queue!");
            }

        }

        public bool Contains(int element)
        {
            return this.queue.Contains(element);
        }
    }

    public class QueueList: ExpressionValue
    {
        public System.Collections.Generic.List<Queue> queueList;

        //default constructor
        public QueueList()
        {
            this.queueList = new System.Collections.Generic.List<Queue>();
        }

        public QueueList(int numQueues)
        {
            this.queueList = new System.Collections.Generic.List<Queue>();
            for (int i = 0; i < numQueues; i++)
            {
                this.queueList.Add(new Queue());
            }
            
        }

        public QueueList(System.Collections.Generic.List<Queue> queueList) {
            this.queueList = new System.Collections.Generic.List<Queue>(queueList);
        }

        public override string ExpressionID
        {
            get
            {
                String returnString = "";
                foreach (Queue element in this.queueList)
                {
                    returnString += element.ToString() + ",";
                }
                if (returnString.Length > 0)
                {
                    returnString = returnString.Substring(0, returnString.Length - 1);
                }

                return returnString;
            }
        }

        //override
        public override string ToString()
        {
            return "[" + ExpressionID + "]";

        }

        //override
        public override ExpressionValue GetClone()
        {
            return new QueueList(new System.Collections.Generic.List<Queue>(this.queueList));
        }

        public int Count()
        {
            return this.queueList.Count;
        }

        public Queue Get(int index)
        {
            return this.queueList[index];
        }

        public int DequeueAt(int index)
        {
            return this.queueList[index].Dequeue();
        }

        public void ReplaceAt(int index, Queue queue)
        {
            if (index >= 0 && index < this.queueList.Count) 
            {
                this.queueList[index] = new Queue(queue.queue);
            }
            else
            {
                //throw PAT Runtime exception
                throw new RuntimeException("index is less than 0.o -index is equal to or greater than length of the list.");
            }
        }
    }
}
