using StudentSorter.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace StudentSorter.Utilities
{
    public static class SortingAlgorithms
    {
        public static SortingResult InsertionSort(List<List<string>> data, int sortColumn)
        {
            var stopwatch = Stopwatch.StartNew();
            int comparisons = 0, swaps = 0;
            var sortedData = new List<List<string>>(data);

            for (int i = 1; i < sortedData.Count; i++)
            {
                var key = sortedData[i];
                int j = i - 1;

                while (j >= 0 && Compare(sortedData[j], key, sortColumn) > 0)
                {
                    comparisons++;
                    sortedData[j + 1] = sortedData[j];
                    swaps++;
                    j--;
                }
                sortedData[j + 1] = key;
                swaps++;
            }

            stopwatch.Stop();
            return new SortingResult
            {
                Algorithm = "Insertion Sort",
                Duration = stopwatch.Elapsed.TotalMilliseconds,
                Comparisons = comparisons,
                Swaps = swaps,
                SortedData = sortedData
            };
        }

        public static SortingResult SelectionSort(List<List<string>> data, int sortColumn)
        {
            var stopwatch = Stopwatch.StartNew();
            int comparisons = 0, swaps = 0;
            var sortedData = new List<List<string>>(data);

            for (int i = 0; i < sortedData.Count - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < sortedData.Count; j++)
                {
                    comparisons++;
                    if (Compare(sortedData[j], sortedData[minIndex], sortColumn) < 0)
                    {
                        minIndex = j;
                    }
                }

                var temp = sortedData[minIndex];
                sortedData[minIndex] = sortedData[i];
                sortedData[i] = temp;
                swaps++;
            }

            stopwatch.Stop();
            return new SortingResult
            {
                Algorithm = "Selection Sort",
                Duration = stopwatch.Elapsed.TotalMilliseconds,
                Comparisons = comparisons,
                Swaps = swaps,
                SortedData = sortedData
            };
        }

        public static SortingResult BubbleSort(List<List<string>> data, int sortColumn)
        {
            var stopwatch = Stopwatch.StartNew();
            int comparisons = 0, swaps = 0;
            var sortedData = new List<List<string>>(data);

            for (int i = 0; i < sortedData.Count - 1; i++)
            {
                for (int j = 0; j < sortedData.Count - i - 1; j++)
                {
                    comparisons++;
                    if (Compare(sortedData[j], sortedData[j + 1], sortColumn) > 0)
                    {
                        var temp = sortedData[j];
                        sortedData[j] = sortedData[j + 1];
                        sortedData[j + 1] = temp;
                        swaps++;
                    }
                }
            }

            stopwatch.Stop();
            return new SortingResult
            {
                Algorithm = "Bubble Sort",
                Duration = stopwatch.Elapsed.TotalMilliseconds,
                Comparisons = comparisons,
                Swaps = swaps,
                SortedData = sortedData
            };
        }

        public static SortingResult MergeSort(List<List<string>> data, int sortColumn)
        {
            var stopwatch = Stopwatch.StartNew();
            int comparisons = 0, swaps = 0;
            var sortedData = new List<List<string>>(data);
            MergeSortRecursive(sortedData, 0, sortedData.Count - 1, sortColumn, ref comparisons, ref swaps);
            stopwatch.Stop();
            return new SortingResult
            {
                Algorithm = "Merge Sort",
                Duration = stopwatch.Elapsed.TotalMilliseconds,
                Comparisons = comparisons,
                Swaps = swaps,
                SortedData = sortedData
            };
        }

        private static void MergeSortRecursive(List<List<string>> data, int left, int right, int sortColumn, ref int comparisons, ref int swaps)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;

                MergeSortRecursive(data, left, middle, sortColumn, ref comparisons, ref swaps);
                MergeSortRecursive(data, middle + 1, right, sortColumn, ref comparisons, ref swaps);

                Merge(data, left, middle, right, sortColumn, ref comparisons, ref swaps);
            }
        }

        private static void Merge(List<List<string>> data, int left, int middle, int right, int sortColumn, ref int comparisons, ref int swaps)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            var leftArray = new List<List<string>>(n1);
            var rightArray = new List<List<string>>(n2);

            for (int i = 0; i < n1; ++i)
                leftArray.Add(data[left + i]);
            for (int j = 0; j < n2; ++j)
                rightArray.Add(data[middle + 1 + j]);

            int i1 = 0, j1 = 0, k = left;
            while (i1 < n1 && j1 < n2)
            {
                comparisons++;
                if (Compare(leftArray[i1], rightArray[j1], sortColumn) <= 0)
                {
                    data[k] = leftArray[i1];
                    i1++;
                }
                else
                {
                    data[k] = rightArray[j1];
                    j1++;
                }
                swaps++;
                k++;
            }

            while (i1 < n1)
            {
                data[k] = leftArray[i1];
                i1++;
                k++;
                swaps++;
            }

            while (j1 < n2)
            {
                data[k] = rightArray[j1];
                j1++;
                k++;
                swaps++;
            }
        }

        public static SortingResult QuickSort(List<List<string>> data, int sortColumn)
        {
            var stopwatch = Stopwatch.StartNew();
            int comparisons = 0, swaps = 0;
            var sortedData = new List<List<string>>(data);
            QuickSortRecursive(sortedData, 0, sortedData.Count - 1, sortColumn, ref comparisons, ref swaps);
            stopwatch.Stop();
            return new SortingResult
            {
                Algorithm = "Quick Sort",
                Duration = stopwatch.Elapsed.TotalMilliseconds,
                Comparisons = comparisons,
                Swaps = swaps,
                SortedData = sortedData
            };
        }

        private static void QuickSortRecursive(List<List<string>> data, int low, int high, int sortColumn, ref int comparisons, ref int swaps)
        {
            if (low < high)
            {
                int pi = Partition(data, low, high, sortColumn, ref comparisons, ref swaps);
                QuickSortRecursive(data, low, pi - 1, sortColumn, ref comparisons, ref swaps);
                QuickSortRecursive(data, pi + 1, high, sortColumn, ref comparisons, ref swaps);
            }
        }

        private static int Partition(List<List<string>> data, int low, int high, int sortColumn, ref int comparisons, ref int swaps)
        {
            var pivot = data[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                comparisons++;
                if (Compare(data[j], pivot, sortColumn) <= 0)
                {
                    i++;
                    var temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    swaps++;
                }
            }

            var temp1 = data[i + 1];
            data[i + 1] = data[high];
            data[high] = temp1;
            swaps++;
            return i + 1;
        }

        private static int Compare(List<string> row1, List<string> row2, int sortColumn)
        {
            var value1 = row1[sortColumn];
            var value2 = row2[sortColumn];

            return Comparer<string>.Default.Compare(value1, value2);
        }
    }
}
