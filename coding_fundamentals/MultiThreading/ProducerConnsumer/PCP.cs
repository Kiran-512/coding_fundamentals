using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace All.Design.Patterns.MultiThreading.ProducerConnsumer
{
    public class ProducerConsumerWithThreads
    {
        private static readonly Queue<int> queue = new Queue<int>();
        //private static volatile object lockObj = new object();
        private static readonly object lockObj = new object();
        private static readonly int maxQueueSize = 10;
        private static readonly int minQueueSize = 0;

        private static volatile bool isProducerWaiting = false;
        private static volatile bool isConsumerWaiting = false;

        static void Produce()
        {
            int i = 0;
            while (true)
            {
                lock (lockObj)
                {
                    // Wait until the queue has space
                    if (queue.Count == maxQueueSize)
                    {
                        isProducerWaiting = true;
                        Console.WriteLine("Waiting for consumer to consume, as queue is FULL, by releasng lock on lockObj: " + queue.Count);
                        Monitor.Wait(lockObj);
                        isProducerWaiting = false;
                    }

                    // Produce an item and add it to the queue
                    queue.Enqueue(i);
                    Console.WriteLine($"Produced: {i++}");

                    // Signal the consumer that an item is available
                    if (isConsumerWaiting)
                        Monitor.Pulse(lockObj);
                }
                //Thread.Sleep(1000); // Simulate production delay
            }
        }
        static void Consume()
        {
            while (true)
            {
                int item;
                lock (lockObj)
                {
                    if (queue.Count == minQueueSize)
                    {
                        isConsumerWaiting = true;
                        Console.WriteLine("Waiting for producer to produce, as queue is EMPTY, by releasng lock on lockObj:  " + queue.Count);
                        Monitor.Wait(lockObj);
                        isConsumerWaiting = false;
                    }

                    item = queue.Dequeue();
                    Console.WriteLine($"Consumedd : {item}");
                    if (isProducerWaiting)
                        Monitor.Pulse(lockObj);
                }
                //Thread.Sleep(1200); // Simulate consumption delay
            }
        }
        public static void Main1()
        {
            Thread producerThread = new Thread(Produce);
            Console.WriteLine("producer in new state...");
            Thread consumerThread = new Thread(Consume);
            Console.WriteLine("consumer in new state...");

            Console.WriteLine("producer satrting work...");
            producerThread.Start();
            Thread.Sleep(10000);
            Console.WriteLine("consumer came in...");
            consumerThread.Start();

            //consumerThread.Join();

            //var producer = Task.Run(() => Produce());
            //var consumer = Task.Run(() => Consume());

            Console.WriteLine("Processing completed.");
        }
    }
    public class ContinuousProducerConsumerWithTasks
    {
        private static BlockingCollection<int> queue = new BlockingCollection<int>(boundedCapacity: 5);
        static void Producer()
        {
            int item = 0;
            while (true)
            {
                // Add item to the queue (blocks if full)
                queue.Add(item);
                Console.WriteLine($"Produced: {item++}");
                Thread.Sleep(500); // Simulate production delay
            }
            //queue.CompleteAdding(); // Signal completion
        }

        static void Consumer()
        {
            while (true)
            {
                // Take item from the queue (blocks if empty)
                int item = queue.Take();
                Console.WriteLine($"Consumed: {item}");
                Thread.Sleep(1000); // Simulate consumption delay
            }
        }
    }
}

/*
 producer in new state...
consumer in new state...
producer satrting work...
Produced: 0
Produced: 1
Produced: 2
Produced: 3
Produced: 4
Produced: 5
Produced: 6
Produced: 7
Produced: 8
Produced: 9
Waiting for consumer to consume, as queue is FULL, by releasng lock on lockObj: 10
consumer came in...
Processing completed.
Consumedd : 0
Consumedd : 1
Consumedd : 2
Consumedd : 3
Consumedd : 4
Consumedd : 5
Consumedd : 6
Consumedd : 7
Consumedd : 8
Consumedd : 9
Waiting for producer to produce, as queue is EMPTY, by releasng lock on lockObj:  0
Produced: 10
Produced: 11
Produced: 12
Produced: 13
Produced: 14
Produced: 15
Produced: 16
Produced: 17
Produced: 18
Produced: 19
Waiting for consumer to consume, as queue is FULL, by releasng lock on lockObj: 10
Consumedd : 10
Consumedd : 11
Consumedd : 12
Consumedd : 13
Consumedd : 14
Consumedd : 15
Consumedd : 16
Consumedd : 17
Consumedd : 18
Consumedd : 19
Waiting for producer to produce, as queue is EMPTY, by releasng lock on lockObj:  0
Produced: 20
.
.
.
*/