using UnityEngine;

namespace Patterns
{
    public class ObjectPool<T>
    {
        private T[] pool;
        public int PoolSize;
        public ObjectPool(int size)
        {
            PoolSize = size;
            pool = new T[size];
        }

        public T GetItem(int i)
        {
            return pool[i];
        }

        public void SetItem(int index, T item)
        {
            pool[index] = item;
        }
    }
}