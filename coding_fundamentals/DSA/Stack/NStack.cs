using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.DSA.Stack
{
    public class NStack
    {
        int[] Jholi;
        int[] Top;
        int[] Next;

        int freeSpot;
        int size;
        int n;
        public NStack(int _n, int _s)
        {
            freeSpot = 0;
            size = _s;
            n = _n;
            Jholi = new int[_s];
            Top = new int[_n];
            Next = new int[_s];

            for (int i = 0; i < n; i++)
            {
                Top[i] = -1;
            }
            for (int i = 0; i < size; i++)
            {
                Next[i] = i + 1;
            }
            Next[size - 1] = -1;
        }

        public bool Push(int X, int m)
        {
            if (freeSpot == -1)
            {
                return false;
            }
            int currIndex = freeSpot;

            freeSpot = Next[freeSpot];

            Jholi[currIndex] = X;

            //set up link for  mth stack
            Next[currIndex] = Top[m - 1];

            Top[m - 1] = currIndex;

            return true;
        }
        public int Pop(int m)
        {
            if (Top[m - 1] == -1)
            {
                return -1;
            }
            int topIndex = Top[m - 1];

            Top[m - 1] = Next[topIndex];

            Next[topIndex] = freeSpot;

            freeSpot = topIndex;

            return Jholi[topIndex];
        }
    }
}
