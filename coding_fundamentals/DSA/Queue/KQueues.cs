using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.DSA.Queue
{
    public class KQueues
    {
        private int freeSpot { get; set; }
        private int n { get; set; }
        private int k { get; set; }
        private int[] arr { get; set; }
        private int[] next { get; set; }
        private int[] front { get; set; }
        private int[] rear { get; set; }

        public KQueues(int size, int k)
        {
            n = size;
            this.k = k;
            freeSpot = 0;
            arr = new int[n];
            next = new int[n];
            front = new int[k];
            rear = new int[k];
        }

        public bool Push(int val, int qi)
        {
            if (freeSpot == -1)
            {
                return false;
            }
            int currIndex = freeSpot;
            freeSpot = next[freeSpot];

            if (front[k - 1] == -1)
            {
                front[k - 1] = currIndex;
            }
            else
            {
                next[rear[k - 1]] = currIndex;
            }

            next[currIndex] = -1;

            rear[k - 1] = currIndex;

            arr[currIndex] = val;
            return true;
        }

        public int Pop(int k) 
        {
            if (front[k - 1] == -1)
            {
                return -1;
            }
            int frontIndex = front[k - 1];

            front[k - 1] = next[frontIndex];

            next[frontIndex] = freeSpot;
            freeSpot = frontIndex;

            return arr[frontIndex];
        }
    }
}
