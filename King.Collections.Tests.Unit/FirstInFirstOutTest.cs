namespace King.Collections.Test.Unit
{
    using NUnit.Framework;
    using System;
    
    [TestFixture]
    public class FirstInFirstOutTest
    {
        [Test]
        public void Constructor()
        {
            new FirstInFirstOut<int>();
        }

        [Test]
        public void Count()
        {
            var queue = new FirstInFirstOut<bool>();
            Assert.AreEqual(0, queue.Count);
            queue.Enqueue(true);
            Assert.AreEqual(1, queue.Count);
            queue.Dequeue();
            Assert.AreEqual(0, queue.Count);
        }

        [Test]
        public void EnqueueDequeue()
        {
            var queue = new FirstInFirstOut<Guid>();
            var g = Guid.NewGuid();
            queue.Enqueue(g);
            var returned = queue.Dequeue();

            Assert.AreEqual(g, returned);
        }

        [Test]
        public void EnqueueMultipleDequeue()
        {
            var queue = new FirstInFirstOut<Guid>();
            var a = Guid.NewGuid();
            var b = Guid.NewGuid();
            var c = Guid.NewGuid();
            queue.Enqueue(a);
            queue.Enqueue(b);
            queue.Enqueue(c);

            Assert.AreEqual(a, queue.Dequeue());
            Assert.AreEqual(b, queue.Dequeue());
            Assert.AreEqual(c, queue.Dequeue());
        }

        [Test]
        public void EnqueueTooManyDeque()
        {
            var queue = new FirstInFirstOut<Guid>();
            var a = Guid.NewGuid();
            var b = Guid.NewGuid();
            var c = Guid.NewGuid();
            queue.Enqueue(a);
            queue.Enqueue(b);
            queue.Enqueue(c);

            Assert.AreEqual(a, queue.Dequeue());
            Assert.AreEqual(b, queue.Dequeue());
            Assert.AreEqual(c, queue.Dequeue());
            Assert.AreEqual(Guid.Empty, queue.Dequeue());
            Assert.AreEqual(Guid.Empty, queue.Dequeue());
            Assert.AreEqual(Guid.Empty, queue.Dequeue());
            Assert.AreEqual(Guid.Empty, queue.Dequeue());
            Assert.AreEqual(Guid.Empty, queue.Dequeue());
            Assert.AreEqual(Guid.Empty, queue.Dequeue());
            Assert.AreEqual(Guid.Empty, queue.Dequeue());
        }
    }
}