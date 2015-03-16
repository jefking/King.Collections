namespace King.Collections
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Priority Collection
    /// </summary>
    /// <typeparam name="TStored">Type Stored</typeparam>
    public class PriorityCollection<TStored> : IEnumerable<TStored>, ICollection<TStored>, IEnumerable
    {
        #region Members
        /// <summary>
        /// Internal Data Type
        /// </summary>
        protected readonly List<TStored> data;

        /// <summary>
        /// Locking, for synchronization
        /// </summary>
        protected readonly object locker = new object();
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the PriorityCollection class.
        /// </summary>
        public PriorityCollection()
            : this(new List<TStored>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the PriorityCollection class.
        /// </summary>
        /// <param name="count">Count</param>
        public PriorityCollection(int count)
            : this(new List<TStored>(count))
        {
        }

        /// <summary>
        /// Initializes a new instance of the PriorityCollection class.
        /// </summary>
        /// <param name="list">Original List</param>
        private PriorityCollection(List<TStored> list)
            : base()
        {
            this.data = list;
            if (null != this.data
                && 0 < this.data.Count)
            {
                this.data.Sort();
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets Peek at Min Item
        /// </summary>
        public virtual TStored Min
        {
            get
            {
                lock (this.locker)
                {
                    return (0 < this.data.Count) ? this.data[0] : default(TStored);
                }
            }
        }

        /// <summary>
        /// Gets Peek at Max Item
        /// </summary>
        public virtual TStored Max
        {
            get
            {
                lock (this.locker)
                {
                    return (0 < this.data.Count) ? this.data[this.data.Count - 1] : default(TStored);
                }
            }
        }

        /// <summary>
        /// Gets the Count
        /// </summary>
        public virtual int Count
        {
            get
            {
                lock (this.locker)
                {
                    return this.data.Count;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether the collection is read only
        /// </summary>
        public virtual bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Push
        /// </summary>
        /// <remarks>
        /// Sort overhead is implemented on Add
        /// </remarks>
        /// <param name="item">Item</param>
        public virtual void Push(TStored item)
        {
            lock (this.locker)
            {
                this.data.Add(item);
                if (1 < this.data.Count)
                {
                    this.data.Sort();
                }
            }
        }

        /// <summary>
        /// Pop
        /// </summary>
        /// <returns>Item</returns>
        public virtual TStored Pop()
        {
            lock (this.locker)
            {
                if (0 < this.data.Count)
                {
                    TStored item = this.data[this.data.Count - 1];
                    this.data.RemoveAt(this.data.Count - 1);
                    return item;
                }
                else
                {
                    return default(TStored);
                }
            }
        }

        #region IEnumerable<Type> Members
        /// <summary>
        /// Get Enumerator
        /// </summary>
        /// <returns>Enumerator</returns>
        public virtual IEnumerator<TStored> GetEnumerator()
        {
            lock (this.locker)
            {
                return this.data.GetEnumerator();
            }
        }
        #endregion

        #region IEnumerable Members
        /// <summary>
        /// Get Enumerator
        /// </summary>
        /// <returns>Enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            lock (this.locker)
            {
                return this.data.GetEnumerator();
            }
        }
        #endregion

        #region ICollection<Type> Members
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="item">Item</param>
        public virtual void Add(TStored item)
        {
            this.Push(item);
        }

        /// <summary>
        /// Clear
        /// </summary>
        public virtual void Clear()
        {
            lock (this.locker)
            {
                if (this.data.Count > 0)
                {
                    this.data.Clear();
                }
            }
        }

        /// <summary>
        /// Contains Item
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>Contains</returns>
        public virtual bool Contains(TStored item)
        {
            lock (this.locker)
            {
                return this.data.Count > 0 && this.data.Contains(item);
            }
        }

        /// <summary>
        /// Copy To Array
        /// </summary>
        /// <param name="array">Array</param>
        /// <param name="arrayIndex">Array Index</param>
        public virtual void CopyTo(TStored[] array, int arrayIndex)
        {
            lock (this.locker)
            {
                this.data.CopyTo(array, arrayIndex);
            }
        }

        /// <summary>
        /// Remove Item
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>Removed</returns>
        public virtual bool Remove(TStored item)
        {
            lock (this.locker)
            {
                return this.data.Remove(item);
            }
        }
        #endregion
        #endregion
    }
}
