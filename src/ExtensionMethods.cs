namespace King.Collections
{
    using System;
    using System.Collections;

    /// <summary>
    /// Extension Methods
    /// </summary>
    public static class ExtensionMethods
    {
        #region System.ICollection
        /// <summary>
        /// Bubble Sort
        /// </summary>
        /// <param name="collection">Collection</param>
        /// <returns>Sorted Collection</returns>
        public static IEnumerable BubbleSort(this ICollection collection)
        {
            if (null == collection)
            {
                return null;
            }
            if (0 == collection.Count)
            {
                return collection;
            }

            IComparable ptr;
            var array = new IComparable[collection.Count];
            collection.CopyTo(array, 0);
            for (var i = 0; i < array.LongLength; i++)
            {
                for (var j = 0; j <= i; j++)
                {
                    if (0 > array[i].CompareTo(array[j]))
                    {
                        ptr = array[j];
                        array[j] = array[i];
                        array[i] = ptr;
                    }
                }
            }

            return array;
        }

        /// <summary>
        /// Quick Sort
        /// </summary>
        /// <param name="collection">Collection</param>
        /// <returns>Sorted Collection</returns>
        public static IEnumerable QuickSort(this ICollection collection)
        {
            if (null == collection)
            {
                return null;
            }
            if (0 == collection.Count)
            {
                return collection;
            }

            var array = new IComparable[collection.Count];
            collection.CopyTo(array, 0);

            IComparable temp;
            var stack = new Stack();
            IComparable pivot;
            var pivotIndex = 0;
            var leftIndex = pivotIndex + 1;
            var rightIndex = collection.Count - 1;

            stack.Push(pivotIndex);
            stack.Push(rightIndex);

            int leftIndexOfSubSet, rightIndexOfSubset;

            while (stack.Count > 0)
            {
                rightIndexOfSubset = (int)stack.Pop();
                leftIndexOfSubSet = (int)stack.Pop();

                leftIndex = leftIndexOfSubSet + 1;
                pivotIndex = leftIndexOfSubSet;
                rightIndex = rightIndexOfSubset;

                pivot = array[pivotIndex];

                if (leftIndex > rightIndex)
                {
                    continue;
                }

                while (leftIndex < rightIndex)
                {
                    while ((leftIndex <= rightIndex) && (0 >= array[leftIndex].CompareTo(pivot)))
                    {
                        leftIndex++;
                    }

                    while ((leftIndex <= rightIndex) && (0 <= array[rightIndex].CompareTo(pivot)))
                    {
                        rightIndex--;
                    }

                    if (rightIndex >= leftIndex)
                    {
                        temp = array[leftIndex];
                        array[leftIndex] = array[rightIndex];
                        array[rightIndex] = temp;
                    }
                }

                if (pivotIndex <= rightIndex)
                {
                    if (0 > array[rightIndex].CompareTo(array[pivotIndex]))
                    {
                        temp = array[pivotIndex];
                        array[pivotIndex] = array[rightIndex];
                        array[rightIndex] = temp;
                    }
                }

                if (leftIndexOfSubSet < rightIndex)
                {
                    stack.Push(leftIndexOfSubSet);
                    stack.Push(rightIndex - 1);
                }

                if (rightIndexOfSubset > rightIndex)
                {
                    stack.Push(rightIndex + 1);
                    stack.Push(rightIndexOfSubset);
                }
            }

            return array;
        }

        /// <summary>
        /// Selection Sort
        /// </summary>
        /// <param name="collection">Collection</param>
        /// <returns>Sorted Collection</returns>
        public static IEnumerable SelectionSort(this ICollection collection)
        {
            if (null == collection)
            {
                return null;
            }
            if (0 == collection.Count)
            {
                return collection;
            }

            var array = new IComparable[collection.Count];
            collection.CopyTo(array, 0);

            IComparable temp = null;
            var smallestLocation = 0;

            for (var j = 0; j < array.Length - 1; j++)
            {
                smallestLocation = j;

                for (var i = j; i < array.Length; i++)
                {
                    if (0 == array[i].CompareTo(temp))
                    {
                        smallestLocation = i;
                        break;
                    }
                    else if (0 > array[i].CompareTo(array[smallestLocation]))
                    {
                        smallestLocation = i;
                    }
                }

                if (smallestLocation != j)
                {
                    temp = array[smallestLocation];
                    array[smallestLocation] = array[j];
                    array[j] = temp;
                }
            }

            return array;
        }

        /// <summary>
        /// Shell Sort
        /// </summary>
        /// <param name="collection">Collection</param>
        /// <returns>Sorted Collection</returns>
        public static IEnumerable ShellSort(this ICollection collection)
        {
            if (null == collection)
            {
                return null;
            }
            if (0 == collection.Count)
            {
                return collection;
            }

            var array = new IComparable[collection.Count];
            collection.CopyTo(array, 0);

            IComparable temp = null;
            int i, j, increment = 3;
            while (increment > 0)
            {
                for (i = 0; i < array.Length; i++)
                {
                    j = i;
                    temp = array[i];
                    while ((j >= increment)
                        && (0 > temp.CompareTo(array[j - increment])))
                    {
                        array[j] = array[j - increment];
                        j = j - increment;
                    }

                    array[j] = temp;
                }

                if (increment / 2 != 0)
                {
                    increment /= 2;
                }
                else if (increment == 1)
                {
                    break;
                }
                else
                {
                    increment = 1;
                }
            }

            return array;
        }
        #endregion
    }
}