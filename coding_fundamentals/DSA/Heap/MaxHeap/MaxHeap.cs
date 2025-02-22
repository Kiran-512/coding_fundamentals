using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.DSA.Heap.MaxHeap
{
    public class MaxHeap
    {
        private int[] arr { get; set; }//1 based indexing imlementation
        private int size { get; set; }
        private int capacity { get; set; }

        public MaxHeap(int capacity)
        {
            this.capacity = capacity;
            arr = new int[capacity];
            size = 0;
        }
        private void HeapifyUp(int index)
        {
            while (index != 1)
            {
                int parentKaIndex = index / 2;
                if (parentKaIndex >= 0 && arr[parentKaIndex] < arr[index])
                {
                    int temp = arr[parentKaIndex];
                    arr[parentKaIndex] = arr[index];
                    arr[index] = temp;
                    index = parentKaIndex;
                }
            }
        }
        private void HeapifyDown(int index)
        {
            while (true)
            {
                int leftChild = index * 2;
                int rightChild = index * 2 + 1;
                int largestKaIndex = index;
                if (leftChild <= size && arr[leftChild] > arr[largestKaIndex])
                {
                    largestKaIndex = leftChild;
                }
                if (rightChild <= size && arr[rightChild] > arr[largestKaIndex])
                {
                    largestKaIndex = rightChild;
                }
                if (index != largestKaIndex)
                {
                    int temp = arr[largestKaIndex];
                    arr[largestKaIndex] = arr[index];
                    arr[index] = temp;
                    index = largestKaIndex;
                }
                else break;
            }
        }
        public void HeapSort(int[] arr,int length)
        {
            int size = length - 1;
            for (int i = size / 2; i >= 1; i--)
            {
                HeapifyDown(i);
            }
            while (size > 1)
            {
                int temp = arr[1];
                arr[1] = arr[size];
                arr[size] = temp;
                size--;
                HeapifyDown(1);
            }
        }
        public void Push(int value)
        {
            if (size >= capacity) return;
            size++;
            int index = size;
            arr[index] = value;
            while (index > 1)
            {
                int parentIndex = index / 2;
                if (arr[parentIndex] > arr[index])
                {
                    int temp = arr[parentIndex];
                    arr[parentIndex] = arr[index];
                    arr[index] = temp;
                    index = parentIndex;
                }
                else break;
            }
        }
        public int top()
        {
            if (size < 2)//arr.Length < 2
            {
                return 0;//throw exception
            }
            return arr[1];
        }
        public int pop()
        {
            if (arr.Length < 2)
            {
                return 0;//throw exception
            }
            int index = 1;
            int val = arr[index];
            arr[index] = arr[size];
            size--;

            while(true) 
            {
                int leftChild = index * 2;
                int rightChild = index * 2 + 1;
                int maxKaIndex = index;
                if (leftChild < size && arr[maxKaIndex] < arr[leftChild])
                {
                    maxKaIndex = leftChild;
                }
                if (rightChild < size && arr[maxKaIndex] < arr[rightChild])
                {
                    maxKaIndex = rightChild;
                }
                if (maxKaIndex == index)
                {
                    break;//element is at its right position
                }
                else
                {
                    int temp = arr[index];
                    arr[index] = arr[maxKaIndex];
                    arr[maxKaIndex] = temp;
                    index = maxKaIndex;
                }
            }
            return val;
        }
    }
}
