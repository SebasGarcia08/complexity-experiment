using System;
using complexity_experiment.model;
using NUnit.Framework;

namespace complexity_experiment_testing
{
    [TestFixture]
    public class TestSelectionSort
    {
        private static readonly int SET_SIZE = 100;
        private static readonly int START = 1;
        private static readonly int END = 100;
        
        private int[] unSortedArray;
        private int[] sortedArray;
        
        private SelectionSort selectionSort;
        
        [OneTimeSetUp]
        public void GlobalSetup()
        {
            selectionSort = new SelectionSort();
        }

        public void setupSmallData()
        {
            unSortedArray = new int[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};
            sortedArray = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        }

        public void setupBigData()
        {
            unSortedArray = new int[SET_SIZE];
            sortedArray = new int[SET_SIZE];

            Random r = new Random();

            for (int i = 0; i < SET_SIZE; i++)
            {
                unSortedArray[i] = r.Next(START, END);
            }

            sortedArray = unSortedArray;
            Array.Sort(sortedArray, 0, SET_SIZE);
        }
        
        [Test]
        public void TestSmallData()
        {          
            setupSmallData();
            selectionSort.Sort(unSortedArray);
            Assert.AreEqual(sortedArray, unSortedArray);
        }
      
        [Test]
        public void TestBigData()
        {
            setupBigData();
            selectionSort.Sort(unSortedArray);
            Assert.AreEqual(sortedArray, unSortedArray);
        }
    }
}