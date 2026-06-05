using UnityEngine;
using System.Collections.Generic;

public class Pool : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    private Stack<GameObject> poolStack = new Stack<GameObject>();



    /// <summary> intento de particulaws cuando gane
    /// * OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO0
    ///* [SerializeField]
    ///* private Win<GameObject> poolWin = new Win<GameObject>();
    ///*000000000000000000000000000000000000000000000000000
    /// </summary> //*Ganar Particulas
    
    
    
    
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


        ///*INTENTO DE PONERLE PARTICULAS MMMMMMMMMMMMMMMMM
        ///* GameObject obj;
        ///*if (poolWin.Count > 0)
        ///*{
            ///*obj = poolWin.Pop();
            ///*obj.SetActive(true);
        ///*}
        ///*else
        ///*{
            ///*obj = Instantiate(prefab, position, Quaternion.identity);
            ///*obj.AddComponent<PoolObject>().Pool = this;
        ///*}
        ///*activeObjects.Add(obj);
        ///*currentObject = obj;
        /// *INTENTO DE PONERLE PARTICULAS NNNNNNNNNNNNNNNNN
         
         
        
    }           ///*Quitando el GameObject



    ///* ÑÑÑÑÑÑÑÑÑÑÑÑÑÑÑÑÑÑÑÑÑÑÑÑÑÑ
    ///* INTENTO DE PARTICULAS GANAR
    ///*public void  InstantiateObject(Vector3 position)
    ///*{
        ///*GameObject obj;
        ///*if (poolWin.Count > 0)
        ///*{
            ///*obj = poolWin.Pop();
            ///*obj.SetActive(true);
        ///*}
        ///*else
        ///*{
            ///*obj = Instantiate(prefab, position, Quaternion.identity);
            ///*obj.AddComponent<PoolObject>().Pool = this;
        ///*}
        ///*activeObjects.Add(obj);
    ///*return obj;
        ///*currentObject = obj;
    ///*}      

    ///*INTENTO DE PARTUCULAS GANAR
    ///*NNNNNNNNNNNNNNNNNNNNNNNNNNN
    
    
    
    
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
