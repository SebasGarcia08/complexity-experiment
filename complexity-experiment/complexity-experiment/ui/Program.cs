using System;
using complexity_experiment.model;

namespace complexity_experiment.ui
{
    class Program
    {
        static void Main(string[] args)
        {
            var sorter = new MergeSort();
            var array = new []{-34, 34, 36, -95, 0, 1};
            sorter.Sort(array);
            foreach(var item in array)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}