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

            int[] small = LoadData(4096);
            int[] medium = LoadData(8192);
            int[] large = LoadData(16384);
            
            var mergeSorter = new MergeSort();
            var selectionSorter = new SelectionSort();
            
            for (int i = 0; i < REPETITIONS; i++)
            {
                Run("MergeSort", mergeSorter, small.Length, small);
                Run("SelectionSort", selectionSorter, small.Length, small);
                
                Run("MergeSort", mergeSorter, medium.Length, medium);
                Run("SelectionSort", selectionSorter, medium.Length, medium);

                Run("MergeSort", mergeSorter, large.Length, large);
                Run("SelectionSort", selectionSorter, large.Length, large);
            }
        }

        public static void Run(string name, ISortable sorter, int N, int[] array)
        {
            int[] unsortedArray = array;
            
            DateTime start = DateTime.Now; 
           
            sorter.Sort(unsortedArray);
            
            DateTime end = DateTime.Now;
            long elapsedTicks = end.Ticks - start.Ticks;
            Console.WriteLine(name + " " + N + " " + elapsedTicks * 100000); //Picosegundos
        }

        public static int[] LoadData(int N)
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