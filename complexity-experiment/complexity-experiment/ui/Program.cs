using System;
using complexity_experiment.model;
using System.IO;

namespace complexity_experiment.ui
{
    class Program
    {
        public static readonly int REPETITIONS = 5;
        
        static void Main(string[] args)
        {

            for (int i = 0; i < REPETITIONS; i++)
            {
                // 49152 - 1.5 MB
                RunMergeSort(49152);
                RunSelectionSort(49152);

                //  327,680 - 10 MB
                RunMergeSort(327680);
                RunSelectionSort(327680);

                // 491,520 -  15 MB 
                RunMergeSort(491520);
                RunSelectionSort(491520);
            }
        }

        public static void RunMergeSort(int N)
        {
            MergeSort mergeSort = new MergeSort();
            int[] unsortedArray = loadData(N);
            
            DateTime start = DateTime.Now; 
           
            mergeSort.Sort(unsortedArray);
            
            DateTime end = DateTime.Now;
            long elapsedTicks = end.Ticks - start.Ticks;
            Console.WriteLine(N + " " + elapsedTicks * 100); //NanoSeconds
        }
        
        public static void RunSelectionSort(int N)
        {
            SelectionSort selectionSort = new SelectionSort();
            int[] unsortedArray = loadData(N);
            
            DateTime start = DateTime.Now; 
           
            selectionSort.Sort(unsortedArray);
            
            DateTime end = DateTime.Now;
            long elapsedTicks = end.Ticks - start.Ticks;
            Console.WriteLine(N + " " + elapsedTicks * 100); //NanoSeconds
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