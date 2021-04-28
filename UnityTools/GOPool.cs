using UnityEngine;
using UnityToolbox.Tools;

public class GOPool : MonoBehaviour
{
    public GameObject[] types;
    public int poolSize = 50;
    private ObjectPool<GameObject> pool;

    private void Awake()
    {
        pool = new ObjectPool<GameObject>(poolSize);
    }

    private void Start()
    {
        CreatePool();
    }

    public GameObject PopDeactivatedObjectOrReturnNull()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject item = pool.GetItem(i);
            if (!item.activeInHierarchy)
            {
                return item;
            }
        }
        return null;
    }

    private void CreatePool()
    {
        int numberOfTypes = types.Length;
        for (int i = 0; i < poolSize; i++)
        {
            GameObject currentPrefab = types[i % numberOfTypes];
            GameObject item = Instantiate(currentPrefab);
            item.SetActive(false);
            pool.SetItem(i, item);
        }
    }
}