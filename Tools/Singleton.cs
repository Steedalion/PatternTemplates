using System;

namespace UnityToolbox.Tools
{
    public class Singleton<T> : IDisposable where T : new()
    {
        private static T instance;

        private bool instanceAlreadyExists => instance != null;

        public static T Instance()
        {
            if (instance == null) instance = new T();
            return instance;
        }

        public Singleton()
        {
            if (instanceAlreadyExists)
            {
                throw new MultipleSingleton();
            }
        }


        public void Dispose()
        {
            Console.WriteLine("Disposing " + this);
            //TODO: Should a signleton have dispose?
        }
    }

    public class MultipleSingleton : Exception
    {
        public MultipleSingleton()
        {
        }

        public MultipleSingleton(string message) : base(message)
        {
        }
    }
}