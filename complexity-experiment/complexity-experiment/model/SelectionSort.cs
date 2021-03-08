namespace complexity_experiment.model
{
    public class SelectionSort : ISortable
    {
        public void Sort(int[] arr)
        {
            var n = arr.Length; 
            for (var  i = 0; i < n - 1; i++) {
                var smallest = i;
                for (var j = i + 1; j < n; j++) {
                    if (arr[j] < arr[smallest]) {
                        smallest = j;
                    }
                }
                var temp = arr[smallest];
                arr[smallest] = arr[i];
                arr[i] = temp;
            }
        }
    }
}