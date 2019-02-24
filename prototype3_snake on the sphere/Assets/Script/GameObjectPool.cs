using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    GameObject body_parent;
    GameObject item_parent;
    //object dictionary
    Dictionary<string, List<GameObject>> poolDic = new Dictionary<string, List<GameObject>>();

    private GameObjectPool() { }

    private static GameObjectPool instance;

    public static GameObjectPool GetInstance()
    {
        if (instance == null)
        {
            instance = new GameObject("GameObjectPool").AddComponent<GameObjectPool>();
        }
        return instance;
    }

    //take object from pool
    public GameObject Object_Instantiate(GameObject newObject, float x, float y, float z, Quaternion q,int index)  //index==-1 not body
    {
        if (index != -1)
            body_parent = GameObject.FindWithTag("Snake");
        else
            item_parent = GameObject.FindWithTag("item");
        Vector3 newPosition = new Vector3(x, y, z);

        string dic_str = newObject.name.Split(' ')[0] + "(Clone)";//key string
                                                                  //if there is no key value in dictionary, then add this key value
        if (!poolDic.ContainsKey(dic_str))
            poolDic.Add(dic_str, new List<GameObject>());

        //if the pool is empty, then instantiate a gameobject,else take the object
        if (poolDic[dic_str].Count == 0)
        {
            GameObject newObj = Instantiate(newObject, newPosition, q) as GameObject;
            if (index != -1)
            {
                newObj.GetComponent<SnakeBody>().SetIndex(index);
                newObj.transform.parent = body_parent.transform;      //set parent
            }
            else
            {
                newObj.transform.parent = item_parent.transform;
            }
            return newObj;
        }
        else
        {
            GameObject obj = poolDic[dic_str][0];
            obj.SetActive(true);
            poolDic[dic_str].Remove(obj); //remove the object
            if (index != -1)
            {
                obj.GetComponent<SnakeBody>().SetIndex(index);
                obj.transform.rotation = q;
            }
            else
            {
                obj.transform.position = newPosition;
                obj.GetComponent<RotateSelf>().ReLookAt();
            }
            return obj;
        }
    }
    //add object to pool
    public void Object_Disable(GameObject disableObject)
    {
        disableObject.SetActive(false);
        string dic_str = disableObject.name;
        poolDic[dic_str].Add(disableObject);
    }
}