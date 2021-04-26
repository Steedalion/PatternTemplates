using System;

namespace UnityToolbox.Tools
{
    public class ObjectPool<T>
    {
        private readonly T[] pool;

        public ObjectPool(int poolSize)
        {
            PoolSize = poolSize;
            pool = new T[poolSize];
        }

        public int PoolSize { get; }

        public T GetItem(int index)
        {
            if (index > PoolSize) throw new PoolOutOfBoundException("Trying to get at index larger than pool size");
            return pool[index];
        }

        public void SetItem(int index, T item)
        {
            if (index > PoolSize) throw new PoolOutOfBoundException("Trying to get at index larger than pool size");
            pool[index] = item;
        }
    }

    public class PoolOutOfBoundException : Exception
    {
        public PoolOutOfBoundException()
        {
        }

        public PoolOutOfBoundException(string message) : base(message)
        {
        }

        public PoolOutOfBoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}