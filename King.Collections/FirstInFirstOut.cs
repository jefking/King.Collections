namespace King.Collections
{
    using System.Collections.Generic;

    /// <summary>
    /// Safety First In First Out Queue
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class FirstInFirstOut<T>
    {
        #region Members
        /// <summary>
        /// Queue
        /// </summary>
        protected readonly Queue<T> queue = null;

        /// <summary>
        /// Lock
        /// </summary>
        protected readonly object safetyLock = new object();
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the FirstInFirstOut class
        /// </summary>
        public FirstInFirstOut()
        {
            this.queue = new Queue<T>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets current Count
        /// </summary>
        public virtual int Count
        {
            get
            {
                lock (this.safetyLock)
                {
                    return this.queue.Count;
                }
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Dequeue
        /// </summary>
        /// <returns>Item</returns>
        public virtual T Dequeue()
        {
            lock (this.safetyLock)
            {
                return this.queue.Count > 0 ? this.queue.Dequeue() : default(T);
            }
        }

        /// <summary>
        /// Enqueue
        /// </summary>
        /// <param name="item">Item</param>
        public virtual void Enqueue(T item)
        {
            lock (this.safetyLock)
            {
                this.queue.Enqueue(item);
            }
        }
        #endregion
    }
}