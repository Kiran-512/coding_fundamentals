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
                    //swap(nums[index], nums[parentIndex]);
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
        public void HeapSort()
        {

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
                    int tempval = arr[parentIndex];
                    arr[parentIndex] = arr[index];
                    arr[index] = arr[parentIndex];
                }
                else break;
            }
        }
        public int top()
        {
            return arr[1];
        }
        public int pop()
        {
            if (arr.Length < 2)
            {
                return 0;//trhow exception
            }
            int index = 1;
            int val = arr[index];
            arr[index] = arr[size];
            size--;

            while (index < size)
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
                    //todo:
                    //swap
                    index = maxKaIndex;
                }
            }
            return val;
        }
        public void heapifyRec()
        {

        }
        public void heapSort()
        {

        }
    }
}
