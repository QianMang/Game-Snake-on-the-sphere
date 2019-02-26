using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Diamond :ObjectManager {
    
    //___GameObject
    private void Start()
    {
        StartCoroutine(WaitForCreate());
    }

    IEnumerator WaitForCreate()
    {
        yield return new WaitForSeconds(2);
        CreateObject();
    }

    public override void CreateObject()
    {
        //random position
        float newPosition_y = Random.Range(-Sphere_Radius, Sphere_Radius);
        float new_radius = Mathf.Sqrt(Sphere_Radius * Sphere_Radius - newPosition_y * newPosition_y);
        float newPosition_x = Random.Range(-new_radius, new_radius);
        float newPosition_z= Mathf.Sqrt(new_radius * new_radius - newPosition_x * newPosition_x);
        
        //
        object_cur[0]= GameObjectPool.GetInstance().Object_Instantiate(object_prefeb,newPosition_x,newPosition_y,newPosition_z,Quaternion.identity,-1);
        CurNum++;

    }

    public override void Effect()
    {
        int effectTime = _Snake.GetComponent<Snake>().GetEffectTime(); 
        for(int i=0;i<effectTime;i++)
            _Snake.GetComponent<Snake>().CreateNewBody();
       
        DisableObject();
        CreateObject();
    }

    public override void DisableObject()
    {
        GameObjectPool.GetInstance().Object_Disable(object_cur[0]);
        CurNum--;
    }
}
