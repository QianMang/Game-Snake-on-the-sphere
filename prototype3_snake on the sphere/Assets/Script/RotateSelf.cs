using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelf : MonoBehaviour {
   
	// Use this for initialization
	void Start () {
        this.transform.LookAt(Vector3.zero);
        this.transform.RotateAround(this.transform.position,this.transform.right,90);
        
	}

    public void ReLookAt()
    {
        
        this.transform.LookAt(Vector3.zero);
        this.transform.RotateAround(this.transform.position, this.transform.right, 90);
    }


    // Update is called once per frame
    void Update () {
        
        this.transform.RotateAround(this.transform.position, this.transform.up, 2);
	}
}
