
using UnityEngine;
using System.Collections.Generic;

public static class StaticObjectPool
{
    private static Dictionary<string, Queue<GameObject>> pools = new Dictionary<string, Queue<GameObject>>();

    public static void Preload(GameObject prefab, int amount)
    {
        if (!pools.ContainsKey(prefab.name))
        {
            pools[prefab.name] = new Queue<GameObject>();
        }

        for (int i = 0; i < amount; i++)
        {
            GameObject obj = Object.Instantiate(prefab);
            obj.name = prefab.name; // Remover (Clone) del nombre
            obj.SetActive(false);
            pools[prefab.name].Enqueue(obj);
        }
    }

    public static GameObject Get(GameObject prefab)
    {

        while (pools[prefab.name].Count > 0)
        {
            GameObject pooledObj = pools[prefab.name].Dequeue();

            if (pooledObj != null)
            {
                pooledObj.SetActive(true);
                return pooledObj;
            }
        }

        GameObject newObj = Object.Instantiate(prefab);
        newObj.name = prefab.name;
        return newObj;
    }

    public static void Return(GameObject obj)
    {
        if (!pools.ContainsKey(obj.name))
        {
            pools[obj.name] = new Queue<GameObject>();
        }

        obj.SetActive(false);
        pools[obj.name].Enqueue(obj);
    }
}

public class DynamicObjectPool : MonoBehaviour
{
    private Dictionary<string, Queue<GameObject>> pool = new Dictionary<string, Queue<GameObject>>();

    public GameObject Get(GameObject prefab)
    {
        string key = prefab.name;

        while (pool.ContainsKey(key) && pool[key].Count > 0)
        {
            GameObject obj = pool[key].Dequeue();
            if (obj != null)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Instantiate(prefab);
        newObj.name = key;
        return newObj;
    }

    public void Return(GameObject obj)
    {
        string key = obj.name;

        if (!pool.ContainsKey(key))
        {
            pool[key] = new Queue<GameObject>();
        }

        obj.SetActive(false);
        pool[key].Enqueue(obj);
    }
}
