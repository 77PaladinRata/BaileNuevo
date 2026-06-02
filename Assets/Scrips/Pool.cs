using UnityEngine;
using System.Collections.Generic;

public class Pool : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    private Stack<GameObject> poolStack = new Stack<GameObject>();
    private HashSet<GameObject> activeObjects = new HashSet<GameObject>();
                ///*Agregando el Object
    private GameObject currentObject;
    public GameObject CurrentObject => currentObject;
       ///*GameObject
    public void  InstantiateObject(Vector3 position)
    {
        GameObject obj;
        if (poolStack.Count > 0)
        {
            obj = poolStack.Pop();
            obj.SetActive(true);
        }
        else
        {
            obj = Instantiate(prefab, position, Quaternion.identity);
            obj.AddComponent<PoolObject>().Pool = this;
        }
        activeObjects.Add(obj);
    ///*return obj;
        currentObject = obj;
    }           ///*Quitando el GameObject
    public void InstantiateObject(Transform parent)
    {    ///*Quitando el Return
        InstantiateObject(parent.position);
        
    }
    public void ReturnToPool(GameObject obj)
    {
        if (activeObjects.Contains(obj))
        {
            activeObjects. Remove (obj);
            obj.SetActive(false);
            poolStack.Push(obj);
        }
    }
    public void DeactivateAll()
    {
        foreach (var obj in activeObjects)
        {
            obj.SetActive(false);
        ///*poolStack.Push(obj);
        }
        activeObjects.Clear();
        currentObject = null;
    }
}
