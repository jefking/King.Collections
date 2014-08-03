namespace King.Collections.Test.Unit
{
    using NUnit.Framework;
    using System;

    /// <summary>
    /// Priority Collection Test
    /// </summary>
    [TestFixture]
    public class PriorityCollectionTest
    {
        #region Valid Cases
        [Test]
        public void PriorityCollectionEnumerate()
        {
            var pc = new PriorityCollection<DateTime>();
            pc.Add(DateTime.Now);
            pc.Add(DateTime.MaxValue);
            pc.Add(DateTime.MinValue);

            DateTime? last = null;
            foreach (DateTime dt in pc)
            {
                if (null != last)
                {
                    Assert.IsTrue(dt > last, "Order should be least to greatest.");
                }

                last = dt;
            }
        }

        [Test]
        public void PriorityCollectionPop()
        {
            var pc = new PriorityCollection<int>();
            pc.Add(0);
            pc.Add(100);
            pc.Add(-100);

            Assert.AreEqual(100, pc.Pop());
        }

        [Test]
        public void PriorityCollectionMinMax()
        {
            var pc = new PriorityCollection<double>();
            pc.Add(123.123);
            pc.Add(999.999);
            pc.Add(111.111);

            Assert.AreEqual(111.111, pc.Min);
            Assert.AreEqual(999.999, pc.Max);
        }

        [Test]
        public void PriorityCollectionICollection()
        {
            var pc = new PriorityCollection<DateTime>();
            pc.Add(DateTime.Now);
            pc.Add(DateTime.MaxValue);
            pc.Add(DateTime.MinValue);

            Assert.AreEqual(false, pc.IsReadOnly);
            Assert.AreEqual(3, pc.Count);
            Assert.AreEqual(true, pc.Contains(DateTime.MaxValue));
            Assert.AreEqual(true, pc.Remove(DateTime.MaxValue));
            pc.Clear();
            Assert.AreEqual(0, pc.Count);
        }
        #endregion
    }
}