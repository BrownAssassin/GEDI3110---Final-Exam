using System.Collections.Generic;
using UnityEngine;

public class BasicPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private Queue<GameObject> availableObjects = new Queue<GameObject>();

    public static BasicPool Instance {get; private set;}
    
    private void Awake()
    {
        Instance = this;
        GrowPool();
    }

    public GameObject GetFromPool()
    {
        var instance = availableObjects.Dequeue();
        instance.SetActive(true);
        return instance;
    }

    private void GrowPool()
    {
        for (int i = 0; i < 13; i++)
        {
            var instanceToAdd = Instantiate(prefab);
            instanceToAdd.transform.SetParent(transform);
            AddToPool(instanceToAdd);
        }
    }

    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        availableObjects.Enqueue(instance);
    }
}
