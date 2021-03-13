using System;
using complexity_experiment.model;
using System.IO;

namespace complexity_experiment.ui
{
    class Program
    {
        public static readonly int REPETITIONS = 100;
        
        static void Main(string[] args)
        {

            int[] small = loadData(4096);
            int[] medium = loadData(8192);
            int[] large = loadData(16384);
            
            for (int i = 0; i < REPETITIONS; i++)
            {
                // 49152 - 1.5 MB
                RunMergeSort(small.Length, small);
                RunSelectionSort(small.Length, small);

                //  327,680 - 10 MB
                RunMergeSort(medium.Length, medium);
                RunSelectionSort(medium.Length, medium);

                // 491,520 -  15 MB 
                RunMergeSort(large.Length, large);
                RunSelectionSort(large.Length, large);
            }
        }
        
        public static void RunMergeSort(int N, int[] array)
        {
            MergeSort mergeSort = new MergeSort();
            int[] unsortedArray = array;
            
            DateTime start = DateTime.Now; 
           
            mergeSort.Sort(unsortedArray);
            
            DateTime end = DateTime.Now;
            long elapsedTicks = end.Ticks - start.Ticks;
            Console.WriteLine("MergeSort " + N + " " + elapsedTicks * 100000); //Picosegundos
        }
        
        public static void RunSelectionSort(int N, int[] array)
        {
            SelectionSort selectionSort = new SelectionSort();
            int[] unsortedArray = array;
            
            DateTime start = DateTime.Now; 
           
            selectionSort.Sort(unsortedArray);
            
            DateTime end = DateTime.Now;
            long elapsedTicks = end.Ticks - start.Ticks;
            Console.WriteLine("SelectionSort " + N + " " + elapsedTicks * 100000); //NanoSeconds
        }

        public static int[] loadData(int N)
        {
            string[] lines = File.ReadAllLines("../../data/" + N + ".txt");
            int[] numbers = new int[lines.Length];
            for(int i = 0; i < lines.Length; i++)
            {
                numbers[i] = Int32.Parse(lines[i]);
            }
            
            return numbers; 
        }
    }
}