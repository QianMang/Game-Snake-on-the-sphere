using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    public GameObject sphere;
    Vector3 normal;
	// Use this for initialization
	void Start () {
        //normal = this.gameObject.transform.position - Vector3.zero;
        this.gameObject.transform.LookAt(Vector3.zero);
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.RotateAround(sphere.transform.position, -this.transform.right, 30 * Time.deltaTime);
	}
}
