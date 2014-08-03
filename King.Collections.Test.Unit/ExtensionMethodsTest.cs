namespace King.Collections.Test.Unit
{
    using NUnit.Framework;
    using System;
    using System.Collections;

    [TestFixture]
    public class ExtensionMethodsTest
    {
        #region Members
        /// <summary>
        /// Un-Ordered Data Set
        /// </summary>
        private readonly int[] unordered = new int[1000];

        /// <summary>
        /// Ordered Data Set
        /// </summary>
        private readonly int[] ordered = new int[1000];
        #endregion

        #region Initialize
        /// <summary>
        /// Initialize Test
        /// </summary>
        [SetUp]
        public void Init()
        {
            var random = new Random();
            for (int index = 0; index < unordered.Length; index++)
            {
                unordered[index] = random.Next();
            }

            Array.Copy(unordered, ordered, unordered.Length);

            Array.Sort(ordered);
        }
        #endregion

        #region System.IEnumerable
        [Test]
        public void BubbleSort()
        {
            ICollection sortedCol = unordered.BubbleSort();
            int[] sorted = new int[sortedCol.Count];
            sortedCol.CopyTo(sorted, 0);
            for (int index = 0; index < sorted.Length; index++)
            {
                if (ordered[index] != sorted[index])
                {
                    Assert.Fail("Sort order is not consistant.");
                }
            }
        }

        [Test]
        public void QuickSort()
        {
            ICollection sortedCol = unordered.QuickSort();
            int[] sorted = new int[sortedCol.Count];
            sortedCol.CopyTo(sorted, 0);
            for (int index = 0; index < sorted.Length; index++)
            {
                if (ordered[index] != sorted[index])
                {
                    Assert.Fail("Sort order is not consistant.");
                }
            }
        }

        [Test]
        public void SelectionSort()
        {
            ICollection sortedCol = unordered.SelectionSort();
            int[] sorted = new int[sortedCol.Count];
            sortedCol.CopyTo(sorted, 0);
            for (int index = 0; index < sorted.Length; index++)
            {
                if (ordered[index] != sorted[index])
                {
                    Assert.Fail("Sort order is not consistant.");
                }
            }
        }

        [Test]
        public void ShellSort()
        {
            ICollection sortedCol = unordered.ShellSort();
            int[] sorted = new int[sortedCol.Count];
            sortedCol.CopyTo(sorted, 0);
            for (int index = 0; index < sorted.Length; index++)
            {
                if (ordered[index] != sorted[index])
                {
                    Assert.Fail("Sort order is not consistant.");
                }
            }
        }
        #endregion

    }
}