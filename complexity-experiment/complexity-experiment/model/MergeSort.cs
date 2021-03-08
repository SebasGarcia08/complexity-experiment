using System.Collections.Generic;

namespace complexity_experiment.model
{
    public class MergeSort : ISortable
    {
        public void Sort(int[] arr)
        {
            Sort(arr, arr.Length);
        }

	/**
	 * Sorts {@link List<E>} list recursively in-place using merge sort algorithm.
	 * <br>
	 * 
	 * @param list, {@link List<E>} list of type E and size n.
	 * @param n,    the size of {@link List<E>} list.
	 */
	private void Sort(IList<int> list, int n) {
		if (n <= 1) return;

		var mid = n / 2;
		IList<int> left = new List<int>(mid + 1);
		IList<int> right = new List<int>(mid + 1);

		for (var i = 0; i < mid; i++) left.Add(list[i]);
		
		for (var i = mid; i < n; i++) right.Add(list[i]);
		
		Sort(left, mid);
		Sort(right, n - mid);
		
		Merge(list, left, right);
	}

	/**
	 * Merges two already sorted lists into another that maintains the sorting
	 * property specified by {@link Comparator<E>} comp.<br>
	 * 
	 * <b>pre:</b> rightList and leftList are already sorted<br>
	 * 
	 * <b>post:</b> The elements of {@link List<E>} list will be sorted in-place.
	 * 
	 * @param leftList,  a sorted {@link List<E>} of size n and type E
	 * @param rightList, a sorted {@link List<E>} of size m and type E
	 * @param list,      an unsorted {@link List<E>} list of size (n+m) and type E
	 *                   such that its first n elements are the same as
	 *                   <b>leftList</b> elements and its m subsequent elements are
	 *                   the same as <b>rightList</b> elements.
	 */
	public void Merge(IList<int> list, IList<int> leftList, IList<int> rightList) {
		int leftPointer, rightPointer, resultPointer;
		leftPointer = rightPointer = resultPointer = 0;
		
		while (leftPointer < leftList.Count || rightPointer < rightList.Count) {

			if (leftPointer < leftList.Count && rightPointer < rightList.Count) {

				if (leftList[leftPointer] <= rightList[rightPointer])
					list[resultPointer++] =  leftList[leftPointer++];

				else
					list[resultPointer++] = rightList[rightPointer++];

			} else if (leftPointer < leftList.Count) {

				list[resultPointer++] = leftList[leftPointer++];

			} else {

				list[resultPointer++] = rightList[rightPointer++];
			}
		}
	}
    }
}