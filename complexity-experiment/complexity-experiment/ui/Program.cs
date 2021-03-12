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

            int[] small = loadData(49152);
            int[] medium = loadData(327680);
            int[] large = loadData(491520);
            
            for (int i = 0; i < REPETITIONS; i++)
            {
                // 49152 - 1.5 MB
                RunMergeSort(49152, small);
                RunSelectionSort(49152, small);

                //  327,680 - 10 MB
                RunMergeSort(327680, medium);
                RunSelectionSort(327680, medium);

                // 491,520 -  15 MB 
                RunMergeSort(491520, large);
                RunSelectionSort(491520, large);
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
            Console.WriteLine("MergeSort " + N + " " + elapsedTicks * 100); //NanoSeconds
        }
        
        public static void RunSelectionSort(int N, int[] array)
        {
            SelectionSort selectionSort = new SelectionSort();
            int[] unsortedArray = array;
            
            DateTime start = DateTime.Now; 
           
            selectionSort.Sort(unsortedArray);
            
            DateTime end = DateTime.Now;
            long elapsedTicks = end.Ticks - start.Ticks;
            Console.WriteLine("SelectionSort " + N + " " + elapsedTicks * 100); //NanoSeconds
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