using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T:SingletonMonoBehaviour<T>
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError(this + "Trying to instance a second instance of singleton");
        }
        else
        {
            Instance = (T) this;
        }
    }

    protected virtual void OnDestroy()
    {
        if (Instance == null) Instance = null;
    }
}
