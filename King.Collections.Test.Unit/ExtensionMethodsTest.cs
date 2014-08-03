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
            var sortedCol = unordered.BubbleSort();
            var sorted = new int[sortedCol.Count];
            sortedCol.CopyTo(sorted, 0);
            for (var index = 0; index < sorted.Length; index++)
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
            var sortedCol = unordered.QuickSort();
            var sorted = new int[sortedCol.Count];
            sortedCol.CopyTo(sorted, 0);
            for (var index = 0; index < sorted.Length; index++)
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
            var sortedCol = unordered.SelectionSort();
            var sorted = new int[sortedCol.Count];
            sortedCol.CopyTo(sorted, 0);
            for (var index = 0; index < sorted.Length; index++)
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
            var sortedCol = unordered.ShellSort();
            var sorted = new int[sortedCol.Count];
            sortedCol.CopyTo(sorted, 0);
            for (var index = 0; index < sorted.Length; index++)
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