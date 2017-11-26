using System;
using System.Collections;

namespace SequentialCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            /// #### QUEUE ####
            doQueueStuff();

            /// #### STACK ####
            Stack myStack = new Stack();
            myStack.Push("First");
            myStack.Push("Second");
            myStack.Push("Third");
            myStack.Push("Fourth");

            while (myStack.Count > 0)
            {
                Object obj = myStack.Pop();
                Console.WriteLine($"{obj} was popped from the stack.");
            }
            Console.ReadKey();
        }

        private static void doQueueStuff()
        {
            Queue myQueue = new Queue();
            myQueue.Enqueue("First");
            myQueue.Enqueue("Second");
            myQueue.Enqueue("Third");
            myQueue.Enqueue("Fourth");

            while (myQueue.Count > 0)
            {
                Object obj = myQueue.Dequeue();
                Console.WriteLine($"{obj} was removed from the queue.");
            }
            Console.WriteLine(Environment.NewLine);
        }
    }
}
