using System;

namespace _3.__Merge_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    internal class MergeSort<T> where T : IComparable
    {
        private static T[] aux;
        public static void Sort(T[] arr)
        {

        }
        public static void Sort(T[] arr,int lo,int hi)
        {
            if (lo>=hi)
            {
                return;

            }



        }
        public static void Merge(T[] arr, int lo, int mid, int hi)
        {
            if (arr[mid + 1].CompareTo(arr[mid]) > 0)
            {
                return;
            }
            for (int index = lo; index < hi + 1; index++)
            {
                aux[index] = arr[index];
            }

            int i = lo;
            int j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i<mid)
                {
                    arr[k]= aux[j++];
                }
                else if (j>hi)
                {
                    arr[k] = aux[i++];

                }
                else if (aux[j].CompareTo(aux[i])>0)
                {
                    arr[k] = aux[i++];

                }
                else
                {
                    arr[k] = aux[j++];

                }
            }
        }
    }
}
