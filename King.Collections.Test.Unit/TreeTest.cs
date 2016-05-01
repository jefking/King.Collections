namespace King.Collections.Test.Unit
{
    using NUnit.Framework;
    using System;
    
    /// <summary>
    /// Tree Test
    /// </summary>
    [TestFixture]
    public class TreeTest
    {
        #region Error Cases
        [Test]
        public void NullKeyAdd()
        {
            var tree = new Tree<string, string>();
            Assert.That(() => tree.Add(null, "this is a test"), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void NullFind()
        {
            var tree = new Tree<string, string>();
            Assert.That(() => tree.Find(null), Throws.TypeOf<ArgumentNullException>());
        }
        #endregion

        #region Valid Cases
        [Test]
        public void Add()
        {
            var tree = new Tree<int, string>();
            tree.Add(22, "this is 22");
            Assert.AreEqual(1, tree.Count);
            tree.Add(88, "this is 88");
            Assert.AreEqual(2, tree.Count);
        }

        [Test]
        public void Find()
        {
            var tree = new Tree<int, string>();
            tree.Add(22, "this is 22");
            Assert.AreEqual(1, tree.Count);
            tree.Add(88, "this is 88");
            Assert.AreEqual(2, tree.Count);

            Assert.AreEqual("this is 22", tree.Find(22), "Values don't match.");
            Assert.AreEqual("this is 88", tree.Find(88), "Values don't match.");
        }
        #endregion
    }
}