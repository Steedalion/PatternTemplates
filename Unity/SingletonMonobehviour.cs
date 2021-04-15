using System;
using UnityEngine;

namespace Assets.Patterns.Unity
{
    public class SingletonMonobehviour<T> : MonoBehaviour where T : SingletonMonobehviour<T>
    {
        public static T instance;
        public bool IsInitialized => instance == null;

        public static T Instance => instance;


        protected void Awake()
        {
            if (instance != null)
            {
                string msg = "[Singleton] Trying to instantiate a second instance of singleton, " + name;
                throw new MoreThanOneSingletonException(msg);
            }
            else
            {
                instance = (T) this;
            }
        }

        protected virtual void OnDestroy()
        {
            if (instance == this)
            {
                instance = null;
            }
        }
    }

    public class MoreThanOneSingletonException : UnityException
    {
        public MoreThanOneSingletonException(string message) : base(message)
        {
        }

        public MoreThanOneSingletonException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}