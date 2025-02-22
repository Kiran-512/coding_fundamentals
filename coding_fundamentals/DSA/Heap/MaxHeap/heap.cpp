using System;
using System.Collections.Generic;
using System.Text;
// #include <bits/stdc++.h>

namespace All.Design.Patterns.DSA.Heap.MaxHeap
{
    class heap
    {
    private:
        vector<int> nums;

        void heapifyUp(int index)
        {
            while (index > 1)
            {
                int parentIndex = index / 2;
                if (nums[parentIndex] < nums[index])
                {
                    swap(nums[index], nums[parentIndex]);
                    index = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }
        void heapifyDown(int index)
        {
            while (true)
            {
                int len = nums.size();
                int maxIndex = index;
                int leftChild = index * 2;
                int righttChild = index * 2 + 1;

                if (leftChild < len && nums[leftChild] > nums[maxIndex])
                    maxIndex = leftChild;
                if (righttChild < len && nums[righttChild] > nums[maxIndex])
                    maxIndex = righttChild;

                if (index != maxIndex)
                {
                    swap(nums[index], nums[maxIndex]);
                    index = maxIndex;
                }
                else
                {
                    break;
                }
            }
        }

    public:
        heap()
        {
            nums.push_back(-1); // 1 index based heap
        }
        void push(int val)
        {
            nums.push_back(val);
            heapifyUp(heap.size() - 1);
        }
        int top()
        {
            if (nums.size() <= 1)
                throw runtime_error("Heap is empty");
            return nums[1]; // Root is at index 1
        }
        void pop()
        {
            if (nums.size() <= 1)
                throw runtime_error("Heap is empty");

            nums[1] = nums.back();
            nums.pop_back();
            if (heap.size() > 1)
            { // Ensure heap is not empty
                heapifyDown(1);
            }
        }
        bool empty() const
        {
            return heap.size() <= 1;
        }
        void printHeap()
        {
            for (int i = 1; i < heap.size(); ++i)
                cout << heap[i] << " ";
            cout << endl;
        }

        void heapify(vector<int> &arr, int n, int i)
        {
            int largest = i;       // Assume root is the largest
            int left = 2 * i;      // Left child
            int right = 2 * i + 1; // Right child

            // Check if left child exists and is greater than root
            if (left < n && arr[left] > arr[largest])
                largest = left;

            // Check if right child exists and is greater than the largest so far
            if (right < n && arr[right] > arr[largest])
                largest = right;

            // If the largest is not the root, swap and continue heapifying
            if (largest != i)
            {
                swap(arr[i], arr[largest]);
                heapify(arr, n, largest); // Recursively heapify the affected subtree
            }
        }

        void buildHeap(vector<int> &arr, int n)
        { // O(n) complexity and not n.logn even though
            // the  loop takes n time and heapify takes logn time!!!!
            //  Step 1: Build a max heap
            for (int i = n / 2; i >= 1; --i)
            { // for 0 based indexing take i = n/2 - 1 to 0
                heapify(arr, n, i);
            }
        }

        void heapSort(vector<int> &arr)
        {
            int n = arr.size() - 1;
            // Step 1: build heap from array
            buildHeap(arr, n);
            // Step 2: Extract elements from the heap one by one
            while (n != 1)
            {
                // Move the current root (maximum element) to the end
                swap(arr[1], arr[n]);
                n--;
                // Call heapify on the reduced heap
                heapify(arr, n, 1);
            }
        }
    }
}
