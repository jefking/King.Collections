namespace King.Collections
{
    using System;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Tree
    /// </summary>
    /// <typeparam name="TKey">Search Item</typeparam>
    /// <typeparam name="TValue">Data Type</typeparam>
    public class Tree<TKey, TValue>
    {
        #region Members
        /// <summary>
        /// Head Node
        /// </summary>
        private Node<TValue> head = null;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the count of objects in the tree.
        /// </summary>
        public virtual int Count
        {
            get
            {
                var count = 0;
                this.RecursiveCount(ref this.head, ref count);
                return count;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the tree is empty.
        /// </summary>
        public virtual bool IsEmpty
        {
            get
            {
                return this.head == null;
            }
        }

        /// <summary>
        /// Accessor
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Data</returns>
        public virtual TValue this[TKey key]
        {
            get
            {
                return this.Find(key);
            }
            set
            {
                this.Add(key, value);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Inserts an object into the tree.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="data">Data</param>
        public virtual void Add(TKey key, TValue data)
        {
            if (null == key)
            {
                throw new ArgumentNullException("Key");
            }

            var hash = key.GetHashCode();
            
            this.RecursiveAdd(ref this.head, hash, ref data);
        }

        /// <summary>
        /// Finds the object in the tree.
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Value</returns>
        public virtual TValue Find(TKey key)
        {
            if (null == key)
            {
                throw new ArgumentNullException("Key");
            }

            var hash = key.GetHashCode();
            
            return this.RecursiveFind(this.head, hash);
        }

        /// <summary>
        /// Clear
        /// </summary>
        public virtual void Clear()
        {
            this.head = null;
        }

        /// <summary>
        /// Inserts into the tree recursively.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <param name="key">Key</param>
        /// <param name="data">Data</param>
        private void RecursiveAdd(ref Node<TValue> cursor, int key, ref TValue data)
        {
            if (0 > key)
            {
                throw new ArgumentOutOfRangeException("Invalid key, below zero.");
            }

            if (null != cursor)
            {
                if (1 == cursor.Key.CompareTo(key))
                {
                    this.RecursiveAdd(ref cursor.Left, key, ref data);
                }
                else if (-1 == cursor.Key.CompareTo(key))
                {
                    this.RecursiveAdd(ref cursor.Right, key, ref data);
                }
                else
                {
                    throw new ArgumentException("An element with the same key already exists in the Tree.", "key");
                }
            }
            else
            {
                cursor = new Node<TValue>(key, data);
            }
        }

        /// <summary>
        /// Finds the object in the tree recursively.
        /// </summary>
        /// <param name="cursor">Cursor</param>
        /// <param name="key">Key</param>
        /// <returns>Value</returns>
        private TValue RecursiveFind(Node<TValue> cursor, int key)
        {
            if (0 > key)
            {
                throw new ArgumentOutOfRangeException("Invalid key, below zero.");
            }

            if (null != cursor)
            {
                if (1 == cursor.Key.CompareTo(key))
                {
                    return this.RecursiveFind(cursor.Left, key);
                }
                else if (-1 == cursor.Key.CompareTo(key))
                {
                    return this.RecursiveFind(cursor.Right, key);
                }
                else
                {
                    return cursor.Data;
                }
            }

            return default(TValue);
        }

        /// <summary>
        /// Counts the nodes in the tree recursively.
        /// </summary>
        /// <param name="cursor">cursor</param>
        /// <param name="count">number of nodes</param>
        private void RecursiveCount(ref Node<TValue> cursor, ref int count)
        {
            if (null != cursor)
            {
                count++;
                var node = cursor.Right;
                this.RecursiveCount(ref node, ref count);
                node = cursor.Left;
                this.RecursiveCount(ref node, ref count);
            }
        }
        #endregion
    }
}