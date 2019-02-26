using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_x2 : ObjectManager {
    

public override void CreateObject()
    {
        //random position
        float newPosition_y = Random.Range(-Sphere_Radius, Sphere_Radius);
        float new_radius = Mathf.Sqrt(Sphere_Radius * Sphere_Radius - newPosition_y * newPosition_y);
        float newPosition_x = Random.Range(-new_radius, new_radius);
        float newPosition_z = Mathf.Sqrt(new_radius * new_radius - newPosition_x * newPosition_x);

        //
        object_cur[0] = GameObjectPool.GetInstance().Object_Instantiate(object_prefeb, newPosition_x, newPosition_y, newPosition_z, Quaternion.identity, -1);
        
    }

    public override void DisableObject()
    {
        GameObjectPool.GetInstance().Object_Disable(object_cur[0]);
        
    }

    public override void Effect()
    {
        _Snake.GetComponent<Snake>().SetEffectTime(2);
        DisableObject();
        this.GetComponent<UIManager>().BuffActive(true);
        
        StartCoroutine(BuffTime());
    }

    // Use this for initialization
    void Start () {
        CurNum = 0;
        MaxNum = 1;
        CreateObject();
        CurNum++;
	}

    private void Update()
    {
        if (CurNum < MaxNum)
        {
            CurNum++;
            StartCoroutine(WaitForCreate(Random.Range(10, 20)));
        }
    }

    IEnumerator BuffTime()
    {
        yield return new WaitForSeconds(10);
        _Snake.GetComponent<Snake>().SetEffectTime(1);
        this.GetComponent<UIManager>().BuffActive(false);
        CurNum--;
    }

    IEnumerator WaitForCreate(float time)
    {
        yield return new WaitForSeconds(time);
        CreateObject();
    }


	
}
