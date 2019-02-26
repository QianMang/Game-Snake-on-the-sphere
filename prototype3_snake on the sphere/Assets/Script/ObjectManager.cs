using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectManager : MonoBehaviour {

    public int CurNum;
    public int MaxNum;
    public GameObject object_prefeb;
    //public GameObject mainCamera;
    public GameObject _Snake;
    protected GameObject[] object_cur=new GameObject[10];
    protected const float Sphere_Radius = 1.05f;
	
    public abstract void CreateObject();

    public abstract void Effect();

    public abstract void DisableObject();
}
